using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Resources;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers.GuildsController
{
    [Authorize]
    public class ThievesGuildController : Controller
    {
        private readonly ThievesRepository _thievesRepository =
            new ThievesRepository(AnkhMorporkGameContext.Create());

        private CurrentPlayerProcessor _playerProcessor = new CurrentPlayerProcessor();

        public ActionResult Index()
        {
            var thieve = ThievesGuild.GetThieve();
            return View(thieve);
        }
        public ActionResult Action()
        {
            --ThievesGuild.TheftLimit;
            return View();
        }

        public ActionResult ActionNo()
        {
            --ThievesGuild.TheftLimit;
            return View();
        }
        public ActionResult AnswerYes()
        {
            CurrentPlayerProcessor.CurrentPlayer = CurrentPlayerProcessor.PlayerManager.FindById(User.Identity.GetUserId());

            CurrentPlayerProcessor.CurrentPlayer.LoseMoney(ThievesGuild.MoneySteel);

            CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);

            return CurrentPlayerProcessor.CurrentPlayer.Money <= 0 ? RedirectToAction("OutOfMoney", "Player") : RedirectToAction("Action");
        }
        public ActionResult AnswerNo()
        {
            CurrentPlayerProcessor.CurrentPlayer = CurrentPlayerProcessor.PlayerManager.FindById(User.Identity.GetUserId());

            CurrentPlayerProcessor.CurrentPlayer.LoseMoney(ThievesGuild.MoneySteel);

            CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);

            return RedirectToAction("ActionNo");
        }
    }
}