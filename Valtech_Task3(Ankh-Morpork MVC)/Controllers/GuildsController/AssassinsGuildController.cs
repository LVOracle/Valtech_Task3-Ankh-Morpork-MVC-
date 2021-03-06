using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Guilds;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers.GuildsController
{
    [Authorize]
    public class AssassinsGuildController : Controller
    {
        private CurrentPlayerProcessor _playerProcessor = new CurrentPlayerProcessor();

        private readonly AssassinsRepository _assassinsRepository =
            new AssassinsRepository(AssassinsDbContext.Create());

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
                assassin.IsOccupied == false && (assassin.MinRange <= money && money <= assassin.MaxRange)).ToList();

            if (listOfAvailableAssassins.Any())
            {
                CurrentPlayerProcessor.CurrentPlayer = CurrentPlayerProcessor.PlayerManager.FindById(User.Identity.GetUserId());

                CurrentPlayerProcessor.CurrentPlayer.LoseMoney(money);

                CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);

               AssassinsGuild.ChangeOccupiedAssassins(_assassinsRepository,listOfAvailableAssassins);
            }

            if (CurrentPlayerProcessor.CurrentPlayer.Money <= 0)
                return RedirectToAction("OutOfMoney", "Player");

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