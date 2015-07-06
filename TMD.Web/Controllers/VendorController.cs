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
    public class VendorController : Controller
    {
        private readonly IVendorService vendorService;

        public VendorController(IVendorService vendorService)
        {
            this.vendorService = vendorService;
        }
        //
        // GET: /Vendor/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Vendor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Vendor/Create
        public ActionResult Create(long? id)
        {
            VendorModel model = new VendorModel();            
            if (id != null)
            {
                var vendor = vendorService.GetVendor((long)id);
                if (vendor != null)
                    model = vendor.CreateFromServerToClient();
            }
            return View(model);
        }

        //
        // POST: /Vendor/Create
        [HttpPost]
        public ActionResult Create(VendorModel vendor)
        {
            try
            {
                if (vendor.VendorId == 0)
                {
                    vendor.RecCreatedBy = User.Identity.Name;
                    vendor.RecCreatedDate = DateTime.Now;
                }
                vendor.RecLastUpdatedBy = User.Identity.Name;
                vendor.RecLastUpdatedDate = DateTime.Now;
                if (vendorService.AddVendor(vendor.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Product category has been saved successfully.", IsSaved = true };
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Vendor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Vendor/Edit/5
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
        // GET: /Vendor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Vendor/Delete/5
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
