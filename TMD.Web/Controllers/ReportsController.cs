using System.Web.Mvc;

namespace TMD.Web.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sales()
        {
            return View();
        }
    }
}
