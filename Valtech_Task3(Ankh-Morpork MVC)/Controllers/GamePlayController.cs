using System.Web.Mvc;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.ViewModels;
using Valtech_Task3_Ankh_Morpork_MVC_.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class GamePlayController : Controller
    {
        // GET: GamePlay
        public ActionResult Index()
        {
            return RedirectToAction("Index", GuildProcessor.GetRandomGuild());
        }
        public ActionResult GameOver()
        {
            return View();
        }
    }
}