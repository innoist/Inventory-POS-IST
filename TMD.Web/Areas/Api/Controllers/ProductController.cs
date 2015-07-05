using System.Web.Http;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels.ApiModels;

namespace TMD.Web.Areas.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET api/<controller>
        public ProductModel Get()
        {
            return new ProductModel{Name = "Custom"};
        }

        // GET api/<controller>/5
        public ProductApiModel Get(int id)
        {
            if (id <= 0) return new ProductApiModel();

            var product = productService.GetProduct((long)id);
            if (product == null) return new ProductApiModel();

            var productApiModel=product.CreateApiModelServerToClient();
            productApiModel.AvailableItems = productService.GetAvailableProductItem(id);

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