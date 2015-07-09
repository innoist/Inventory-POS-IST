using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrdersService orderService;
        private readonly IProductService productService;
        private readonly IOrderItemService orderItemService;

        public ActionResult Index()
        {
            //if (Request.UrlReferrer == null || Request.UrlReferrer.AbsolutePath == "/Orders/EbayItemImportLV")
            //{
            //    Session["PageMetaData"] = null;
            //}

            OrderSearchRequest viewModel = Session["PageMetaData"] as OrderSearchRequest;

            Session["PageMetaData"] = null;
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            var toReturnModel = new OrderViewModel
            {
                SearchRequest = viewModel ?? new OrderSearchRequest()
            };
            
            return View(toReturnModel);
        }
        [HttpPost]
        public ActionResult Index(OrderSearchRequest oRequest)
        {
            OrderSearchResponse oResponse = orderService.GetOrdersSearchResponse(oRequest);
            List<OrderListViewModel> oList = oResponse.Orders.Select(x => x.CreateFromServerToLVClient()).ToList();
            OrderViewModel oVModel = new OrderViewModel();
            oVModel.data = oList;
            oVModel.recordsTotal = oResponse.TotalCount;
            oVModel.recordsFiltered = oResponse.FilteredCount;



            Session["PageMetaData"] = oRequest;
            var toReturn = Json(oVModel, JsonRequestBehavior.AllowGet);
            return toReturn;
        }

        public OrderController(IOrdersService orderService, IProductService productService, IOrderItemService orderItemService)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.orderItemService = orderItemService;
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
        public ActionResult Create(OrderModel orderDetail)
        {
            try
            {
                SetUserInfo(orderDetail);
                // TODO: Add insert logic here
                if (orderDetail.OrderId <= 0)
                {

                    var order = orderDetail.CreateFromClientToServer();
                   
                    orderService.AddService(order);
                    //orderService.
                    //orderService.AddService()
                }
                else
                {
                    var order = orderDetail.CreateFromClientToServer();
                    
                    orderService.UpdateService(order);
                    orderItemService.AddUpdateService(order);
               
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        private void SetUserInfo(OrderModel orderDetail)
        {
               string name = User.Identity.Name;
            if (orderDetail.OrderId <= 0)
            {
                orderDetail.RecCreatedDate = orderDetail.RecLastUpdatedDate = DateTime.Now;

                orderDetail.RecCreatedBy = orderDetail.RecLastUpdatedBy = name;

            }
            else
            {
                orderDetail.RecLastUpdatedDate = DateTime.Now;
                orderDetail.RecLastUpdatedBy = User.Identity.Name;

            }

            List<OrderItemModel> NotUpdatedList = new List<OrderItemModel>();

            foreach (var item in orderDetail.OrderItems)
            {
                if (item.OrderItemId <= 0)
                {
                    item.RecCreatedDate = item.RecLastUpdatedDate = DateTime.Now;
                    item.RecCreatedBy = item.RecLastUpdatedBy = User.Identity.Name;
                    //GetSalePrice and set it
                    var product = productService.GetProduct(item.ProductId);
                    item.MinSalePriceAllowed = product.MinSalePriceAllowed;
                    item.PurchasePrice = product.PurchasePrice;
                    item.SalePrice = product.SalePrice;
                }
                else
                {
                    if (item.IsModified)
                    {
                        item.RecLastUpdatedBy = name;
                        item.RecLastUpdatedDate = DateTime.Now;
                        //FETCH FROM DB AND SET THE VALUES
                        var orderItem = orderItemService.GetOrderItemById(item.OrderItemId);
                        item.SalePrice = orderItem.SalePrice;
                        item.PurchasePrice = orderItem.PurchasePrice;
                        item.MinSalePriceAllowed = orderItem.MinSalePriceAllowed;
                        item.RecCreatedBy = orderItem.RecCreatedBy;
                        item.RecCreatedDate = orderItem.RecCreatedDate;
                        item.OrderId = orderDetail.OrderId;

                    }
                    else
                    {
                        NotUpdatedList .Add(item);
                    }
                }
            }
            foreach (var orderItemModel in NotUpdatedList)
            {
                orderDetail.OrderItems.Remove(orderItemModel);
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
