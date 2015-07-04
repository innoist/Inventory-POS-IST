using System.Linq;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels;

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

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ProductViewModel productViewModel=new ProductViewModel();
             var categories=productCategoryService.GetAllProductCategories().ToList();
            if (categories.Any())
                productViewModel.ProductCategories = categories.Select(x => x.CreateFromServerToClient());
            return View(productViewModel);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel product)
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
