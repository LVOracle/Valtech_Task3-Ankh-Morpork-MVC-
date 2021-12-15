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
    public class BeggarsGuildController : Controller
    {
        private readonly BeggarsRepository _beggarsRepository =
            new BeggarsRepository(BeggarsDbContext.Create());

        private CurrentPlayerProcessor _playerProcessor = new CurrentPlayerProcessor();

        public ActionResult Index()
        {
            var beggar = BeggarsGuild.GetBeggar();

            return View(beggar);
        }
        public ActionResult Action()
        {
            var beggar = TempData["Beggar"] as Beggars;

            return View(beggar);
        }
        public ActionResult AnswerYes(Beggars beggary)
        {
            var beggar = _beggarsRepository.GetGuildMembersEnumerable.FirstOrDefault(b => b.Name == beggary.Name);

            CurrentPlayerProcessor.CurrentPlayer = CurrentPlayerProcessor.PlayerManager.FindById(User.Identity.GetUserId());

            TempData["Beggar"] = beggar;

            if (beggar.GiveMoney == 0)
            {
                --CurrentPlayerProcessor.CurrentPlayer.AmountOfBeer;
            }

            if (CurrentPlayerProcessor.CurrentPlayer.AmountOfBeer < 0)
            {
                CurrentPlayerProcessor.CurrentPlayer.HasBeer = false;

                CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);

                return RedirectToAction("GameOver", "GamePlay");
            }

            CurrentPlayerProcessor.CurrentPlayer.LoseMoney(beggar.GiveMoney);

            CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);

            return CurrentPlayerProcessor.CurrentPlayer.Money <= 0 ? RedirectToAction("OutOfMoney", "Player") : RedirectToAction("Action");
        }
        public ActionResult AnswerNo()
        {
            return RedirectToAction("GameOver", "GamePlay");
        }
    }
}