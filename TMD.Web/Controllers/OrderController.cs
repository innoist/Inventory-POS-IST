using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Threading.Tasks;
namespace TMD.Web.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class OrderController : BaseController
    {
        private readonly IOrdersService orderService;
        private readonly IProductService productService;
        private readonly IOrderItemService orderItemService;
        private readonly IProductConfigurationService configurationService;

        public ActionResult Index()
        {
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
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            OrderSearchResponse oResponse = orderService.GetOrdersSearchResponse(oRequest);
            List<OrderListViewModel> oList = oResponse.Orders.Select(x => x.CreateFromServerToLVClient()).ToList();
            OrderViewModel oVModel = new OrderViewModel();
            oVModel.data = oList;
            oVModel.recordsTotal = oResponse.TotalCount;
            oVModel.recordsFiltered = oResponse.FilteredCount;
            oVModel.GrossSale = oList.Sum(x => x.TotalSale);
            oVModel.Discount = oList.Sum(x => x.TotalDiscount);
            oVModel.NetSale = oList.Sum(x => x.NetSales);


            Session["PageMetaData"] = oRequest;
            var toReturn = Json(oVModel, JsonRequestBehavior.AllowGet);
            return toReturn;
        }

        public OrderController(IOrdersService orderService, IProductService productService, IOrderItemService orderItemService, IProductConfigurationService configurationService)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.orderItemService = orderItemService;
            this.configurationService = configurationService;
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
            //Setting Max discount
            int MaxDiscountInt = 0;
            int.TryParse( new Utility().GetConfigMaxDiscount(Session, configurationService,User.IsInRole(Utility.AdminRoleName)), out MaxDiscountInt);
            toSend.AllowedMaxDiscount = MaxDiscountInt;
            
            
            return View(toSend);
        }

        // POST: ProductCategory/Create
        [HttpPost]
        public ActionResult Create(OrderModel orderDetail)
        {
            try
            {
               

                SetUserInfo(orderDetail);
                string email = new Utility().GetConfigEmail(Session, configurationService);
                // TODO: Add insert logic here
                if (orderDetail.OrderId <= 0)
                {

                    var order = orderDetail.CreateFromClientToServer();
                    if (ValidateDiscount(order))
                    {

                        orderService.AddService(order);
                        orderDetail.OrderId = order.OrderId;
                        new Task(() => { SendEmail(order, email); }).Start();
                        order.Comments = "fast speed";
                        new Task(() => {
                            UpdateCreatedOrder(order);
                             }).Start();
                        TempData["message"] = new MessageViewModel
                        {
                            Message = "Order has been created with ID: " + order.OrderId,
                            IsSaved = true
                        };
                        TempData["order"] = order;
                        return RedirectToAction("PrintOrder", "Order", new { id = order.OrderId});
                    }
                    else
                    {
                        ViewBag.MessageVM = new MessageViewModel
                        {
                            Message = "Order Discount Exceed the permit limit",
                            IsError = true
                        };
                        return View(orderDetail);
                    }
                }
                else
                {
                    var order = orderDetail.CreateFromClientToServer();
                    
                    orderService.UpdateService(order);
                    orderItemService.AddUpdateService(order);
                    new Task(() => { SendEmail(order, email); }).Start();
                    TempData["message"] = new MessageViewModel { Message = "Order has been updated successfully.", IsSaved = true };
                    return RedirectToAction("Index");
                }
                
            //    new Task(() => { Foo2(42, "life, the universe, and everything"); }).Start();
                return View();

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        private void UpdateCreatedOrder(Order order) {
            foreach (var item in order.OrderItems)
            {
                var product = productService.GetProduct(item.ProductId);
                item.MinSalePriceAllowed = product.MinSalePriceAllowed;
                item.PurchasePrice = product.PurchasePrice;
                item.SalePrice = product.SalePrice;
            }
            orderService.UpdateService(order);


        }
        private bool ValidateDiscount(Order order)
        {
            return true;
            var maxDiscAllowed = decimal.Parse( new Utility().GetConfigMaxDiscount(Session, configurationService,User.IsInRole(Utility.AdminRoleName)))/100;
            var sumDiscount = order.OrderItems.Sum(x => x.Discount);
            var sumRs = order.OrderItems.Sum(x => x.SalePrice*x.Quantity);
            decimal perc = sumDiscount / sumRs;

            if (perc > maxDiscAllowed)
                return false;
            return true;
        }

        private bool SendEmail(Order order,string email)
        {
            throw new Exception("asd");
            if (string.IsNullOrEmpty(email) || email.ToLower() == "none")
            {
                return false;
            }
            string subject = "";
            if (order.IsModified)
            {
                subject = "Modified: Order: " + order.OrderId;
            }
            else
            {
                subject = "Created: Order: " + order.OrderId;
            }
            var grossSale = order.OrderItems.Sum(x => x.SalePrice*x.Quantity);
            var totalDiscount = order.OrderItems.Sum(x => x.Discount);
            string body = "Gross Sale: " + grossSale;
            body += " Total Discount: " + totalDiscount;
            body += " Total Qty: " + order.OrderItems.Sum(x => x.Quantity);
            body += " Net Sale: " + (grossSale - totalDiscount).ToString();
            string szProdcutCode = string.Empty;
            string szProductName = string.Empty;

            foreach (var item in order.OrderItems)
            {
                szProdcutCode += item.ProductId+",";
                if(item.Product != null)
                    szProductName += item.Product.Name+",";
            }
            body += " CODEs " + szProdcutCode + " Names " + szProductName;
            if (order.IsModified)
            {
                //Just enter that order was modified
                body = "Order Modified at: " + DateTime.Now.ToShortDateString() + " By:" + User.Identity.Name;
            }
            Utility.SendEmailAsync(email,subject,body);
            return true;
            //Utility.SendEmailAsync(email,"");
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
                    //var product = productService.GetProduct(item.ProductId);
                    //item.MinSalePriceAllowed = product.MinSalePriceAllowed;
                    //item.PurchasePrice = product.PurchasePrice;
                    //item.SalePrice = product.SalePrice;
                    if(orderDetail.OrderId>0)
                        orderDetail.IsModified = true;//Means a previous order had a new entery. I know this because orderid >0 and orderitem id<=0
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
                        orderDetail.IsModified = true;//means there is some modification in order. Only qty and Discount can be updated
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

        // POST: ProductCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                if (orderService.DeleteOrder(id))
                {
                    return Json(new { response = "Successfully deleted!", status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { response = "Probably, record has already been deleted.", status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { response = "Oops, there is some problem, please try again.", status = (int)HttpStatusCode.BadRequest }, JsonRequestBehavior.AllowGet);
            }
            
        }

        //public string GetConfigEmail()
        //{
        //    if (Session[Utility.ConfigEmail] == null)
        //    {
        //        var config = configurationService.GetDefaultConfiguration();
        //        var email = config.Emails;
        //        if (string.IsNullOrEmpty(email))
        //            Session[Utility.ConfigEmail] = "NONE";
        //        else
        //            Session[Utility.ConfigEmail] = email;
        //        return email;
                
        //    }
        //    else
        //    {

        //        return Session[Utility.ConfigEmail].ToString();
        //    }
        //}

        //public string GetConfigMaxDiscount()
        //{
        //    if (User.IsInRole(Utility.AdminRoleName))
        //    {
        //        Session[Utility.MaxDiscount] = 50;
                
        //    }
        //    else if (Session[Utility.MaxDiscount] == null)
        //    {
        //        var config = configurationService.GetDefaultConfiguration();
        //        var MaxAllowedDiscount = config.MaxAllowedDiscount;

        //        Session[Utility.MaxDiscount] = MaxAllowedDiscount;
               

        //    }
        //    return Session[Utility.MaxDiscount].ToString();
        //}

        public ActionResult PrintOrder(long id)
        {
            Order orderDetails = null;
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            if(TempData["order"] != null)
            {
                orderDetails = TempData["order"] as Order;
            }
            OrderListViewModel oVM = new OrderListViewModel();
            //Order orderDetails = null;
            if (orderDetails == null || orderDetails.OrderId !=  id)
            {
                orderDetails = orderService.GetOrders(id);
            }
            
            oVM = orderDetails.CreateFromServerToLVClient();
            oVM.OrderItems = orderDetails.OrderItems.Select(x => x.CreateFromServerToClient()).ToList();
            return View(oVM);
        }

    }
}
