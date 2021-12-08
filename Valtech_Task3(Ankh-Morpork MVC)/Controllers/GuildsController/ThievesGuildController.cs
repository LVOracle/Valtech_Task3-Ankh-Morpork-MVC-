using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.ViewModels;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers.GuildsController
{
    [Authorize]
    public class ThievesGuildController : Controller
    {
        private GameEntitiesViewModel gm = new GameEntitiesViewModel();

        // GET: ThievesGuild
        public ActionResult Index()
        {
            gm.CurrentPlayer = gm.Manager.FindById(User.Identity.GetUserId());
            gm.CurrentPlayer.Money -= 10m;
            gm.Manager.Update(gm.CurrentPlayer);

            return View(gm);
        }
        public ActionResult Action()
        {
            return View();
        }
        public ActionResult AnswerYes(GameEntitiesViewModel model)
        {
            return RedirectToAction("Action",model);
        }

        public ActionResult AnswerNo()
        {
            return RedirectToAction("GameOver", "GamePlay");
        }
    }
}