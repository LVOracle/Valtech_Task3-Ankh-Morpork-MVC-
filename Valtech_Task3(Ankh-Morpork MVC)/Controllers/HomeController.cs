using System.Web.Mvc;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnkhMorporkGameContext _context = new AnkhMorporkGameContext();
        private readonly AssassinsRepository _repository;

        public HomeController()
        {
            _repository = new AssassinsRepository(_context);
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