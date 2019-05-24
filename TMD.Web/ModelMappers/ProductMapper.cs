using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using TMD.Models.DomainModels;
using TMD.Web.Models;
using TMD.Web.ViewModels;
using TMD.Web.ViewModels.ApiModels;

namespace TMD.Web.ModelMappers
{
    public static class ProductMapper
    {
        public static Product CreateFromClientToServer(this ProductModel source)
        {
            return new Product
            {
                CategoryId = source.CategoryId,
                ProductId = source.ProductId,
                VendorId = source.VendorId,
                ProductBarCode = source.ProductBarCode,
                ProductCode = source.ProductCode,
                Name = source.Name,
                PurchasePrice = source.PurchasePrice,
                SalePrice = source.SalePrice,
                MinSalePriceAllowed = source.MinSalePriceAllowed,
                Comments = source.Comments,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                ImagePath = source.ImagePath,
                ProductImages = source.ProductImages.Select(x=>x.CreateFromClientToServer(source.ProductId)).ToList()
            };
        }

        public static ProductModel CreateFromServerToClient(this Product source)
        {
            return new ProductModel
            {
                CategoryId = source.CategoryId,
                ProductId = source.ProductId,
                VendorId = source.VendorId,
                ProductBarCode = source.ProductBarCode,
                ProductCode = source.ProductCode,
                Name = source.Name,
                PurchasePrice = source.PurchasePrice,
                SalePrice = source.SalePrice,
                MinSalePriceAllowed = source.MinSalePriceAllowed,
                Comments = source.Comments,
                CategoryName = source.ProductCategory.Name,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                ImagePath = source.ProductImages.Any() ? "Yes" : "No",
                ProductImages = source.ProductImages != null && source.ProductImages.Any() ? source.ProductImages.Select(x => x.CreateFromServerToClient()).ToList() : 
                    new List<ProductImageModel> { new ProductImageModel { ItemImagePath = "no-image-found.png", ProductId = source.ProductId } }
            };
        }

        public static ProductApiModel CreateApiModelServerToClient(this Product source)
        {
            return new ProductApiModel
            {
                CategoryId = source.CategoryId,
                ProductId = source.ProductId,
                VendorId = source.VendorId,
                ProductBarCode = source.ProductBarCode,
                ProductCode = source.ProductCode,
                Name = source.Name,
                PurchasePrice = source.PurchasePrice,
                SalePrice = source.SalePrice,
                MinSalePriceAllowed = source.MinSalePriceAllowed,
                Comments = source.Comments,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
            };
        }
    }

    public static class ProductImageMapper
    {
        public static ProductImage CreateFromClientToServer(this ProductImageModel source, long productId)
        {
            return new ProductImage
            {
                ImagePath = source.ItemImagePath,
                ProductId = productId
            };

        }

        public static ProductImageModel CreateFromServerToClient(this ProductImage source)
        {
            var imagePath = source.ImagePath;
            var imagesFolderPath = HttpContext.Current.Server.MapPath("~/Images/Inventory/");
            if (!string.IsNullOrEmpty(source.ImagePath) && !File.Exists(imagesFolderPath + source.ImagePath))
            {
                imagePath = "no-image-found.png";
            }

            return new ProductImageModel
            {
                ItemImagePath = imagePath,
                ProductId = source.ProductId
            };

        }
    }
}