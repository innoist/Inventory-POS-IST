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
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IProductCategoryService productCategoryService;

        public ProductController(IProductService productService,IProductCategoryService productCategoryService)
        {
            this.productService = productService;
            this.productCategoryService = productCategoryService;
        }

        // GET: Products
        public ActionResult Index()
        {
            ProductSearchRequest searchRequest = Session["PageMetaData"] as ProductSearchRequest;
            Session["PageMetaData"] = null;
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;

            var categories = productCategoryService.GetAllProductCategories().ToList();
            return View(new ProductsListViewModel
            {
                SearchRequest = searchRequest ?? new ProductSearchRequest(),
                ProductCategories = categories.Any()?categories.Select(x=>x.CreateFromServerToClient()):new List<ProductCategoryModel>()
            });
        }
        [HttpPost]
        public ActionResult Index(ProductSearchRequest searchRequest)
        {
            ProductsListViewModel viewModel = new ProductsListViewModel();
            try
            {
                ProductSearchResponse searchResponse = productService.GetProductSearchResponse(searchRequest);

                var resultData = searchResponse.Products.Any()
                    ? searchResponse.Products.Select(x => x.CreateFromServerToClient()).ToList()
                    : new List<ProductModel>();

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
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create(long? id)
        {
            ProductViewModel productViewModel=new ProductViewModel();
            if (id!=null)
            {
                var product = productService.GetProduct((long)id);
                if(product!=null)
                    productViewModel.ProductModel = product.CreateFromServerToClient();
            }
            var categories=productCategoryService.GetAllProductCategories().ToList();
            if (categories.Any())
                productViewModel.ProductCategories = categories.Select(x => x.CreateFromServerToClient());
            return View(productViewModel);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            try
            {
                if (productViewModel.ProductModel.ProductId == 0)
                {
                    productViewModel.ProductModel.RecCreatedBy = User.Identity.Name;
                    productViewModel.ProductModel.RecCreatedDate = DateTime.Now;
                }
                productViewModel.ProductModel.RecLastUpdatedBy = User.Identity.Name;
                productViewModel.ProductModel.RecLastUpdatedDate = DateTime.Now;

                //Minimum sale price should not be less than purchase price
                if (productViewModel.ProductModel.MinSalePriceAllowed <
                    productViewModel.ProductModel.PurchasePrice)
                    productViewModel.ProductModel.MinSalePriceAllowed =
                        productViewModel.ProductModel.SalePrice;

                if (productService.SaveProduct(productViewModel.ProductModel.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Product has been saved successfully.", IsSaved = true };
                }
                

                return RedirectToAction("Index");
            }
            catch(Exception exception)
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
