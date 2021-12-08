using System.Web.Mvc;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Play()
        {
            return RedirectToAction("Index", "GamePlay");
        }
    }
}