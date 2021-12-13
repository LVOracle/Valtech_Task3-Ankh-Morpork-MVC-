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
    public class FoolsGuildController : Controller
    {
        private readonly FoolsRepository _foolsRepository =
            new FoolsRepository(AnkhMorporkGameContext.Create());

        private CurrentPlayerProcessor _playerProcessor = new CurrentPlayerProcessor();

        public ActionResult Index()
        {
            var fool = FoolsGuild.GetFool();

            return View(fool);
        }
        public ActionResult Action()
        {
            var fool = TempData["Fool"] as Fools;

            return View(fool);
        }
        public ActionResult AnswerYes(Fools fool)
        {
            var _fool = _foolsRepository.GetGuildMembersEnumerable.FirstOrDefault(b => b.Name == fool.Name);

            CurrentPlayerProcessor.CurrentPlayer = CurrentPlayerProcessor.PlayerManager.FindById(User.Identity.GetUserId());

            if (_fool != null) CurrentPlayerProcessor.CurrentPlayer.EarnMoney(_fool.TakeMoney);

            CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);

            if (CurrentPlayerProcessor.CurrentPlayer.Money <= 0)
                return RedirectToAction("OutOfMoney", "Player");

            TempData["Fool"] = _fool;

            return RedirectToAction("Action");
        }

        public ActionResult ActionNo()
        {
            return View();
        }
        public ActionResult AnswerNo()
        {
            return RedirectToAction("ActionNo");
        }
    }
}