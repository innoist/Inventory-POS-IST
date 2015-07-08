using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
      [Authorize(Roles = "Admin, Employee")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            IEnumerable<CustomerModel> customers = customerService.GetAllCustomers().Select(x=>x.CreateFromServerToClient());
            return View(customers);
        }

        //
        // GET: /Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Customer/Create
        public ActionResult Create(long? id)
        {
            CustomerModel model = new CustomerModel();
            if (id != null)
            {
                var customer = customerService.GetCustomer((long)id);
                if (customer != null)
                    model = customer.CreateFromServerToClient();
            }
            return View(model);
        }

        //
        // POST: /Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerModel customer)
        {
            try
            {
                if (customer.Id == 0)
                {
                    customer.RecCreatedBy = User.Identity.Name;
                    customer.RecCreatedDate = DateTime.Now;
                }
                customer.RecLastUpdatedBy = User.Identity.Name;
                customer.RecLastUpdatedDate = DateTime.Now;
                if (customerService.AddCustomer(customer.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Customer has been saved successfully.", IsSaved = true };
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Edit/5
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

        //
        // GET: /Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Delete/5
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
