using System.Web.Mvc;
using TMD.Web.Models;

namespace TMD.Web.Controllers
{
    public class OrderController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductCategory/Create
        public ActionResult Create()
        {

            return View();
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
