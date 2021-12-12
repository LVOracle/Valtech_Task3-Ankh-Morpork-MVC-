using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class GamePlayController : Controller
    {
        private GameController GameController => new GameController(User.Identity.GetUserId());
        // GET: GamePlay
        public ActionResult Index()
        { 
            GameController.Step();
            return RedirectToAction("Index", GuildProcessor.GetRandomGuild());
        }
        public ActionResult GameOver()
        {
            GameController.MoneyChecker = CurrentPlayerProcessor.CurrentPlayer.Money;
            return View();
        }
        public ActionResult Play()
        {
            GameController.StartInitialization();
            return RedirectToAction("Index");
        }
    }
}