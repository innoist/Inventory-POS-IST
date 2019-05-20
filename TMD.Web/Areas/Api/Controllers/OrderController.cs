using System;
using System.Linq;
using System.Web.Http;
using TMD.Interfaces.IServices;
using TMD.Models.RequestModels;
using TMD.Web.ModelMappers;
using TMD.Web.Models;

namespace TMD.Web.Areas.Api.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private readonly IOrdersService orderService;

        public OrderController(IOrdersService orderService)
        {
            if (orderService == null)
            {
                throw new ArgumentNullException(nameof(orderService));
            }
            this.orderService = orderService;
        }

        // GET api/<controller>
        public IHttpActionResult Get([FromUri] OrderSearchRequest request)
        {
            var response = orderService.GetOrdersSearchResponse(request);
            var orders = response.Orders.Select(p => p.CreateFromServerToClient()).ToList();
            return Ok(new { Orders = orders, response.FilteredCount });
        }

        // POST api/<controller>
        public IHttpActionResult Post(OrderModel order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            return Ok(true);
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