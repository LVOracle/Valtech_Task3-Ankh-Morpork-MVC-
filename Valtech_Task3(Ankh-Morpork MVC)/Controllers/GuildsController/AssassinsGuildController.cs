using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers.GuildsController
{
    [Authorize]
    public class AssassinsGuildController : Controller
    {
        private PlayerProcessor pp = new PlayerProcessor();

        private readonly AssassinsRepository _assassinsRepository =
            new AssassinsRepository(AnkhMorporkGameContext.Create());

        // GET: AssassinsGuild
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Action()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Action(decimal money)
        {
            var listOfAvailableAssassins = _assassinsRepository.GetGuildMembersEnumerable.Where(assassin =>
                assassin.IsOccupied == false && (assassin.MinRange <= money && money <= assassin.MaxRange));

            if (listOfAvailableAssassins.Any())
            {
                PlayerProcessor.CurrentPlayer = PlayerProcessor.PlayerManager.FindById(User.Identity.GetUserId()); 

                PlayerProcessor.CurrentPlayer.LoseMoney(money);
                
                PlayerProcessor.PlayerManager.Update(PlayerProcessor.CurrentPlayer);
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