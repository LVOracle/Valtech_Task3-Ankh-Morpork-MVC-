using System.Web.Mvc;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnkhMorporkGameContext _context = new AnkhMorporkGameContext();
        private readonly AnkhMorporkRepository _repository;

        public HomeController()
        {
            _repository = new AnkhMorporkRepository(_context);
        }
        public ActionResult Index()
        {
            return View(_repository);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}