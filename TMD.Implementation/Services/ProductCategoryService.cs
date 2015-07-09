using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class ProductCategoryService:IProductCategoryService
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IProductMainCategoryRepository productMainCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository,IProductMainCategoryRepository productMainCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.productMainCategoryRepository = productMainCategoryRepository;
        }

        public ProductCategory GetProductCategory(long productCategoryId)
        {
            return productCategoryRepository.Find(productCategoryId);
        }

        public CreateCategoryResponseModel GetProductCategoryResponse(long? productCategoryId)
        {
            CreateCategoryResponseModel responseModel=new CreateCategoryResponseModel();
            if (productCategoryId != null)
            {
                responseModel.ProductCategory = productCategoryRepository.Find((long)productCategoryId);
            }
            responseModel.ProductMainCategories = productMainCategoryRepository.GetAll().ToList();
            return responseModel;
        }

        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            return productCategoryRepository.GetAll().OrderBy(x=>x.Name).ToList();
        }

        public long AddProductCategory(ProductCategory productCategory)
        {
            if (productCategory.CategoryId > 0)
                productCategoryRepository.Update(productCategory);
            else
                productCategoryRepository.Add(productCategory);
            
            productCategoryRepository.SaveChanges();
            return productCategory.CategoryId;
        }
    }
}
