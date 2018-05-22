using System.Web.Mvc;

namespace Vape.CMS.UI.Controllers
{
    public class DashboardController : Controller
    {
        // Get Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}