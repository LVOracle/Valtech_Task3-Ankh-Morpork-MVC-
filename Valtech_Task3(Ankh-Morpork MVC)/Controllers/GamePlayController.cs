using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class GamePlayController : Controller
    {
        private GameEngine _gameEngine => new GameEngine(User.Identity.GetUserId());
        // GET: GamePlay
        public ActionResult Index()
        {
            _gameEngine.Step();
            return RedirectToAction("Index", GuildProcessor.GetRandomGuild());
        }
        public ActionResult GameOver()
        {
            GameEngine.MoneyChecker = CurrentPlayerProcessor.CurrentPlayer.Money;
            return View();
        }
        public ActionResult Play()
        {
            _gameEngine.StartInitialization();
            return RedirectToAction("Index");
        }
    }
}