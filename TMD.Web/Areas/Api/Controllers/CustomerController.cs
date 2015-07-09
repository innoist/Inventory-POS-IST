using System.Web.Http;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels.ApiModels;

namespace TMD.Web.Areas.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET api/<controller>
        public CustomerModel Get()
        {
            return new CustomerModel { Name = "Customer" };
        }

        // GET api/<controller>/5
        public CustomerModel Get(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            var response = customerService.GetCustomerByEmailOrPhone(id);
            return response == null ? null : response.CreateFromServerToClient();
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