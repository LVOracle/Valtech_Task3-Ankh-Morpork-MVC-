using System.Web.Mvc;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

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