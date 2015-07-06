using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class ProductCategoryService:IProductCategoryService
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public ProductCategory GetProductCategory(long productCategoryId)
        {
            return productCategoryRepository.Find(productCategoryId);
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
