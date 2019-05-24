using System;
using System.Linq;
using System.Web.Http;
using TMD.Interfaces.IServices;
using TMD.Models.RequestModels;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.ApiModels;

namespace TMD.Web.Areas.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService productService;
        private readonly IProductCategoryService productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            if (productCategoryService == null)
            {
                throw new ArgumentNullException(nameof(productCategoryService));
            }
            this.productService = productService;
            this.productCategoryService = productCategoryService;
        }

        // GET api/<controller>
        public IHttpActionResult Get([FromUri] ProductSearchRequest request)
        {
            var response = productService.GetProductSearchResponse(request);
            var products = response.Products.Select(p => p.CreateFromServerToClient()).OrderBy(p => p.Name).ToList();
            return Ok(new { Products = products, response.FilteredCount });
        }

        // GET api/<controller>
        [Route("~/api/Product/ByCategory")]
        public IHttpActionResult Get([FromUri] ProductCategorySearchRequest request)
        {
            var response = productCategoryService.GetAll(request);
            var productCategories = response.ProductCategories.Select(p => p.CreateFromServerToClient(false)).ToList();
            return Ok(new { ProductCategories = productCategories, response.FilteredCount });
        }

        // GET api/<controller>
        [Route("~/api/Product/MainCategories")]
        public IHttpActionResult Get()
        {
            var response = productCategoryService.GetProductCategoryResponse(null);
            return Ok(new { ProductMainCategories = response.ProductMainCategories.Select(p => p.CreateFromServerToClient()).ToList() });
        }

        // GET api/<controller>/5
        public ProductApiModel Get(string id, bool searchBarCode =true)
        {
            if (string.IsNullOrEmpty(id)) return new ProductApiModel();

            var response = productService.GetProductByAnyCode(id, searchBarCode);
            if (response.Product == null) return new ProductApiModel();

            var productApiModel = response.Product.CreateApiModelServerToClient();
            productApiModel.AvailableItems = response.AvailableItems;

            return productApiModel;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}