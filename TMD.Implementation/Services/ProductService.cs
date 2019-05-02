using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IInventoryItemRepositoy inventoryItemRepositoy;
        private readonly IOrderItemsRepository orderItemsRepository;
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IProductImageRepository productImageRepository;


        public ProductService(IProductRepository productRepository, IInventoryItemRepositoy inventoryItemRepositoy,
            IOrderItemsRepository orderItemsRepository, IProductCategoryRepository productCategoryRepository, IProductImageRepository productImageRepository)
        {
            this.productRepository = productRepository;
            this.inventoryItemRepositoy = inventoryItemRepositoy;
            this.orderItemsRepository = orderItemsRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.productImageRepository = productImageRepository;
        }

        public Product GetProduct(long productId)
        {
            return productRepository.Find(productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll().ToList();
        }

        public long SaveProduct(Product product)
        {

            if (product.ProductId > 0)
            {
                Product productFromDb = productRepository.Find(product.ProductId);
                if (product.ProductImages.Count > 0)
                    UpdateImages(product, productFromDb);
                productRepository.Update(product);
            }

            else
            {
                if (product.ProductImages.Count > 0)
                    AddImages(product);
                productRepository.Add(product);
            }

            productRepository.SaveChanges();
            return product.ProductId;
        }

        public void AddImages(Product product)
        {
            if (product.ProductImages != null)
            {
                foreach (ProductImage productImage in product.ProductImages)
                {
                    ProductImage image = new ProductImage
                    {
                        ProductId = product.ProductId,
                        ImagePath = productImage.ImagePath
                    };
                    productImageRepository.Add(image);
                }
            }
        }

        public void UpdateImages(Product product, Product productFromDb)
        {
            IEnumerable<ProductImage> dbList = productFromDb.ProductImages.ToList();
            IEnumerable<ProductImage> clientList = product.ProductImages;

            if (clientList != null && clientList.Count() > 0)
            {
                //Add New Items
                foreach (ProductImage image in clientList)
                {
                    if (image.ItemImageId > 0)
                    {
                        productImageRepository.Update(image);
                    }
                    else
                    {
                        ProductImage productImage = new ProductImage
                        {
                            ProductId = product.ProductId,
                            ImagePath = image.ImagePath
                        };
                        productImageRepository.Add(productImage);
                    }
                }
                //Delete Items that were removed from ClientList
                if (dbList != null)
                    foreach (ProductImage image in dbList)
                    {
                        if (clientList.All(x => x.ItemImageId != image.ItemImageId))
                        {
                            productImageRepository.Delete(image);
                        }
                    }
            }
            else
            {
                //Delete All Items if List from Client is Empty
                foreach (ProductImage image in dbList)
                {
                    productImageRepository.Delete(image);
                }
            }
        }

        public long GetAvailableProductItem(long productId)
        {
            var itemInInventory = inventoryItemRepositoy.GetItemCountInInventory(productId);
            var itemInOrders = orderItemsRepository.GetItemCountInOrders(productId);
            return itemInInventory - itemInOrders;
        }

        public ProductSearchResponse GetProductSearchResponse(ProductSearchRequest searchRequest)
        {
            return productRepository.GetProductSearchResponse(searchRequest);
        }

        public ProductResponse GetProductResponse(long? productId)
        {
            ProductResponse responseResult = new ProductResponse();
            if (productId != null)
            {
                var product = GetProduct((long)productId);
                if (product != null)
                    responseResult.Product = product;
            }
            responseResult.ProductCategories = productCategoryRepository.GetAll().ToList();
            return responseResult;
        }

        public ProductSearchResponseByAnyCode GetProductByAnyCode(string code, bool searchBarCode = true)
        {
            ProductSearchResponseByAnyCode response = new ProductSearchResponseByAnyCode();
            var product = productRepository.GetProductByAnyCode(code, searchBarCode);
            if (product != null)
            {
                response.Product = product;
                response.AvailableItems = GetAvailableProductItem(product.ProductId);
            }
            return response;
        }
    }
}