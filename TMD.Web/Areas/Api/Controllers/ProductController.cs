using System.Linq;
using System.Web.Http;
using TMD.Interfaces.IServices;
using TMD.Models.RequestModels;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.ApiModels;

namespace TMD.Web.Areas.Api.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET api/<controller>
        public IHttpActionResult Get([FromUri] ProductSearchRequest request)
        {
            var response = productService.GetProductSearchResponse(request);
            var products = response.Products.Select(p => p.CreateFromServerToClient()).ToList();
            return Ok(new { Products = products, response.TotalCount });
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