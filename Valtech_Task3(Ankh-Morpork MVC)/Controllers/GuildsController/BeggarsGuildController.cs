using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.ViewModels;
using Valtech_Task3_Ankh_Morpork_MVC_.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers.GuildsController
{
    [Authorize]
    public class BeggarsGuildController : Controller
    {
        private GameEntitiesViewModel gm = new GameEntitiesViewModel();

        // GET: BeggarsGuild
        public ActionResult Index()
        {
            var beggar = BeggarsGuild.GetBeggar();
            gm.Beggar = beggar;
            gm.CurrentPlayer = gm.Manager.FindById(User.Identity.GetUserId());
            gm.CurrentPlayer.Money -= 10m;
            gm.Manager.Update(gm.CurrentPlayer);

            return View(gm);
        }
        public ActionResult Action()
        {
            return View();
        }
        public ActionResult AnswerYes(Beggars beggar)
        {
            return RedirectToAction("Action", beggar);
        }
        public ActionResult AnswerNo()
        {
            return RedirectToAction("GameOver", "GamePlay");
        }
    }
}