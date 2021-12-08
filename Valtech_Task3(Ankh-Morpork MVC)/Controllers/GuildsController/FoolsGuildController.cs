using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.ViewModels;
using Valtech_Task3_Ankh_Morpork_MVC_.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers.GuildsController
{
    [Authorize]
    public class FoolsGuildController : Controller
    {
        public GameEntitiesViewModel gm = new GameEntitiesViewModel();

        // GET: FoolsGuild
        public ActionResult Index()
        {
            var fool = FoolsGuild.GetFool();
            gm.Fool = fool;
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
            return View();
        }
    }
}