using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TMD.Implementation.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Web.ModelMappers;
using TMD.Web.Models;

namespace TMD.Web.Areas.Api.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private readonly IOrdersService orderService;

        public ApplicationUserManager UserManager => Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        
        public OrderController(IOrdersService orderService)
        {
            if (orderService == null)
            {
                throw new ArgumentNullException(nameof(orderService));
            }
            this.orderService = orderService;
        }

        // GET api/<controller>
        public async Task<IHttpActionResult> Get([FromUri] OrderSearchRequest request)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest($"User doesn't exist againt id {userId}");
            }

            request.CustomerId = user.CustomerId;
            var response = orderService.GetOrdersSearchResponse(request);
            var orders = response.Orders.Select(p => p.CreateFromServerToClient()).ToList();
            return Ok(new { Orders = orders, response.FilteredCount });
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post(OrderModel order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            var userId = User.Identity.GetUserId();
            order.RecCreatedBy = userId;
            order.RecLastUpdatedBy = userId;
            order.RecCreatedDate = DateTime.Now;
            order.RecLastUpdatedDate = DateTime.Now;
            // Set Order Items created by and date
            order.OrderItems?.ForEach(oi =>
            {
                oi.RecCreatedBy = userId;
                oi.RecLastUpdatedBy = userId;
                oi.RecCreatedDate = DateTime.Now;
                oi.RecLastUpdatedDate = DateTime.Now;
            });

            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            { 
                return BadRequest($"User doesn't exist againt id {userId}");
            }

            order.CustomerId = user.CustomerId;
            orderService.AddService(order.CreateFromClientToServer());
            return Ok(true);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(OrderModel order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            return Ok(true);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}