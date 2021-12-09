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

        private PlayerProcessor pp = new PlayerProcessor();

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

            PlayerProcessor.CurrentPlayer = PlayerProcessor.PlayerManager.FindById(User.Identity.GetUserId());

            if (beggar != null) PlayerProcessor.CurrentPlayer.LoseMoney(beggar.GiveMoney);

            PlayerProcessor.PlayerManager.Update(PlayerProcessor.CurrentPlayer);

            TempData["Beggar"] = beggar;
            
            return RedirectToAction("Action");
        }
        public ActionResult AnswerNo()
        {
            return RedirectToAction("GameOver", "GamePlay");
        }
    }
}