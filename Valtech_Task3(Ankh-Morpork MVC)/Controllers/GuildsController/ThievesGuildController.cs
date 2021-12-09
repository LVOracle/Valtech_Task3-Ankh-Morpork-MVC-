using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.ViewModels;
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
            var thieve = TempData["Thieve"] as Thieves;

            return View(thieve);
        }
        public ActionResult AnswerYes(Thieves thieve_)
        {
            var thieve = _thievesRepository.GetGuildMembersEnumerable.FirstOrDefault(b => b.Name == thieve_.Name);

            CurrentPlayerProcessor.CurrentPlayer = CurrentPlayerProcessor.PlayerManager.FindById(User.Identity.GetUserId());

            if (thieve != null) CurrentPlayerProcessor.CurrentPlayer.LoseMoney(ThievesGuild.MoneySteel);

            CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);

            TempData["Thieve"] = thieve;

            return RedirectToAction("Action");
        }
        public ActionResult AnswerNo()
        {
            return RedirectToAction("GameOver", "GamePlay");
        }
    }
}