using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Resources;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers.GuildsController
{
    [Authorize]
    public class BeggarsGuildController : Controller
    {
        private readonly BeggarsRepository _beggarsRepository =
            new BeggarsRepository(AnkhMorporkGameContext.Create());

        private CurrentPlayerProcessor playerProcessor = new CurrentPlayerProcessor();

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

            if (beggar != null) CurrentPlayerProcessor.CurrentPlayer.LoseMoney(beggar.GiveMoney);

            CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);

            TempData["Beggar"] = beggar;
            
            return RedirectToAction("Action");
        }
        public ActionResult AnswerNo()
        {
            return RedirectToAction("GameOver", "GamePlay");
        }
    }
}