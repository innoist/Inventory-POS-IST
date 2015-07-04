using System.Activities.Expressions;
using System.Collections.Generic;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersService orderService;
        
        // GET: ProductCategory
        public ActionResult Index()
        {
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View();
        }

        public OrderController(IOrdersService orderService)
        {
            this.orderService = orderService;
        }

        // GET: ProductCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductCategory/Create
        public ActionResult Create(long ? id)
        {
            OrderModel toSend = new OrderModel();
            if (id == null || id == 0)
                toSend.OrderItems = new List<OrderItemModel>();
            else
            {
                //Means Edit case
                toSend = orderService.GetOrders(id.Value).CreateFromServerToClient();
            }

            return View(toSend);
        }

        // POST: ProductCategory/Create
        [HttpPost]
        public ActionResult Create(ProductCategoryModel productCategory)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
