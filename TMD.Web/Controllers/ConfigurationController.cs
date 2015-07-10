using System;
using System.Linq;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConfigurationController : BaseController
    {
        private readonly IProductConfigurationService configurationService;
        private readonly IVendorService vendorService;

        public ConfigurationController(IProductConfigurationService configurationService, IVendorService vendorService)
        {
            this.configurationService = configurationService;
            this.vendorService = vendorService;
        }

        // GET: Configuration
        public ActionResult Index()
        {
            return View();
        }

        // GET: Configuration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Configuration/Create
        public ActionResult Create()
        {
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            var congif = configurationService.GetDefaultConfiguration();
            var vendor = vendorService.GetActiveVendors();

            if(congif == null)
                congif = new ProductConfiguration();

            ProductConfigurationViewModel oVM = new ProductConfigurationViewModel();
            oVM.Configuration = congif;
            oVM.vendorModel = vendor.Select(x => x.CreateFromServerToClient());

            return View(oVM);
        }

        // POST: Configuration/Create
        [HttpPost]
        public ActionResult Create(ProductConfiguration configuration)
        {
            try
            {
                if (configuration.Id == 0)
                {
                    configuration.RecCreatedBy = User.Identity.Name;
                    configuration.RecCreatedDate = DateTime.Now;
                }
                configuration.RecLastUpdatedBy = User.Identity.Name;
                configuration.RecLastUpdatedDate = DateTime.Now;
                if (configurationService.SaveConfiguration(configuration) > 0)
                {
                    TempData["message"] = new MessageViewModel { Message = "Configuration has been saved successfully.", IsSaved = true };
                }

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Configuration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Configuration/Edit/5
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

        // GET: Configuration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Configuration/Delete/5
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
