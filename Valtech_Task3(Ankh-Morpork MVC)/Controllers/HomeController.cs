using System.Web.Mvc;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnkhMorporkGameContext _context = new AnkhMorporkGameContext();
        private AnkhMorporkRepository _repository;
        public ActionResult Index()
        {
            _repository = new AnkhMorporkRepository(_context);
            var assassins = _repository.GetAssassinsEnumerable;
            ViewBag.Assassins = assassins;
            return View();
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