using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.ViewModels;
using Valtech_Task3_Ankh_Morpork_MVC_.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers.GuildsController
{
    [Authorize]
    public class BeggarsGuildController : Controller
    {
        private GameEntitiesViewModel gm = new GameEntitiesViewModel();

        private readonly BeggarsRepository _beggarsRepository =
            new BeggarsRepository(AnkhMorporkGameContext.Create());

        public ActionResult Index()
        {
            var beggar = BeggarsGuild.GetBeggar();

            gm.Beggar = beggar;
            
            gm.CurrentPlayer = gm.Manager.FindById(User.Identity.GetUserId());
            
            return View(gm);
        }
        public ActionResult Action()
        {
            var viewModel = TempData["ViewModel"] as GameEntitiesViewModel;

            return View(viewModel);
        }
        public ActionResult AnswerYes(Beggars beggary)
        {
            var beggar = _beggarsRepository.GetGuildMembersEnumerable.FirstOrDefault(b => b.Name == beggary.Name);

            gm.Beggar = beggar;
            
            gm.CurrentPlayer = gm.Manager.FindById(User.Identity.GetUserId());
            
            gm.CurrentPlayer.LoseMoney(beggar.GiveMoney);
            
            gm.Manager.Update(gm.CurrentPlayer);

            TempData["ViewModel"] = gm;
            
            return RedirectToAction("Action");
        }
        public ActionResult AnswerNo()
        {
            return RedirectToAction("GameOver", "GamePlay");
        }
    }
}