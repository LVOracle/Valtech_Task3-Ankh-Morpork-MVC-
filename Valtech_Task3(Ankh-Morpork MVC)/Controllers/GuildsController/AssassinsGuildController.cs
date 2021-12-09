using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.ViewModels;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers.GuildsController
{
    [Authorize]
    public class AssassinsGuildController : Controller
    {
        private GameEntitiesViewModel gm = new GameEntitiesViewModel();

        private readonly AssassinsRepository _assassinsRepository =
            new AssassinsRepository(AnkhMorporkGameContext.Create());

        // GET: AssassinsGuild
        public ActionResult Index()
        {
            gm.CurrentPlayer = gm.Manager.FindById(User.Identity.GetUserId());

            return View(gm);
        }
        public ActionResult Action()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Action(decimal money)
        {
            gm.CurrentPlayer = gm.Manager.FindById(User.Identity.GetUserId());

            var listOfAvailableAssassins = _assassinsRepository.GetGuildMembersEnumerable.Where(assassin =>
                assassin.IsOccupied == false && (assassin.MinRange <= money && money <= assassin.MaxRange));

            if (listOfAvailableAssassins.Any())
            {
                gm.CurrentPlayer.LoseMoney(money);
                gm.Manager.Update(gm.CurrentPlayer);
            }

            TempData["availableAssassins"] = listOfAvailableAssassins;

            return RedirectToAction("AvailableAssassins");
        }

        public ActionResult AvailableAssassins()
        {
            var listAssassinsEnumerable = TempData["availableAssassins"] as IEnumerable<Assassins>;

            return View(listAssassinsEnumerable);
        }
        public ActionResult AnswerYes()
        {
            return RedirectToAction("Action");
        }

        public ActionResult AnswerNo()
        {
            return RedirectToAction("GameOver", "GamePlay");
        }
    }
}