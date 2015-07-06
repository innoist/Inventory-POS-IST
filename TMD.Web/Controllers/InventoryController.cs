using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class InventoryController : BaseController
    {
        private readonly IInventoryItemService inventoryItemService;
        private readonly IProductService productService;
        private readonly IVendorService vendorService;


        public InventoryController(IInventoryItemService inventoryItemService,IProductService productService,IVendorService vendorService)
        {
            this.inventoryItemService = inventoryItemService;
            this.productService = productService;
            this.vendorService = vendorService;
        }

        // GET: Inventory
        public ActionResult Index()
        {
            InventoryItemSearchRequest searchRequest = Session["PageMetaData"] as InventoryItemSearchRequest;
            Session["PageMetaData"] = null;
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;

            var vendors = vendorService.GetAllVendors().ToList();
            var viewModel = new InventoryItemsListViewModel();

            viewModel.SearchRequest = searchRequest ?? new InventoryItemSearchRequest();
            viewModel.Vendors = vendors.Any()
                ? vendors.Select(x => x.CreateFromServerToClient())
                : new List<VendorModel>();
            
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(InventoryItemSearchRequest searchRequest)
        {
            InventoryItemsListViewModel viewModel = new InventoryItemsListViewModel();
            try
            {
                InventoryItemSearchResponse searchResponse = inventoryItemService.GetInventoryItemSearchResponse(searchRequest);

                var resultData = searchResponse.InventoryItems.Any()
                    ? searchResponse.InventoryItems.Select(x => x.CreateListServerToClient()).ToList()
                    : new List<InventoryItemListModel>();

                viewModel.data = resultData;
                viewModel.recordsTotal = searchResponse.TotalCount;
                viewModel.recordsFiltered = searchResponse.FilteredCount;

                // Keep Search Request in Session
                Session["PageMetaData"] = searchRequest;
                return Json(viewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                TempData["message"] = new MessageViewModel { Message = "There is some problem, please try again.", IsError = true };
                return View(viewModel);
            }
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/Create
        public ActionResult Create(long? id)
        {
            InventoryItemViewModel inventoryItemViewModel = new InventoryItemViewModel();

            var responseResult = inventoryItemService.GetInventoryItemResponse(id);
            if (responseResult.Vendors.Any())
                inventoryItemViewModel.Vendors = responseResult.Vendors.Select(x => x.CreateFromServerToClient());
            if (responseResult.InventoryItem != null)
                inventoryItemViewModel.InventoryItem = responseResult.InventoryItem.CreateFromServerToClient();
            return View(inventoryItemViewModel);
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(InventoryItemViewModel inventoryItemViewModel)
        {
            try
            {
                if (inventoryItemViewModel.InventoryItem.ItemId == 0)
                {
                    inventoryItemViewModel.InventoryItem.RecCreatedBy = User.Identity.Name;
                    inventoryItemViewModel.InventoryItem.RecCreatedDate = DateTime.Now;
                }
                inventoryItemViewModel.InventoryItem.RecLastUpdatedBy = User.Identity.Name;
                inventoryItemViewModel.InventoryItem.RecLastUpdatedDate = DateTime.Now;

               if (inventoryItemService.AddInventoryItem(inventoryItemViewModel.InventoryItem.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Inventory has been saved successfully.", IsSaved = true };
                }


                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inventory/Edit/5
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

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/Delete/5
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
