using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class GamePlayController : Controller
    {
        private GameController _gameController;
        // GET: GamePlay
        public ActionResult Index()
        {
            _gameController = new GameController(User.Identity.GetUserId());
            return RedirectToAction("Index", GuildProcessor.GetRandomGuild());
        }
        public ActionResult GameOver()
        {
            return View();
        }
    }
}