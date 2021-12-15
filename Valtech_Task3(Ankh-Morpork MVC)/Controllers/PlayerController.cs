using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Resources;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;
using Valtech_Task3_Ankh_Morpork_MVC_.ViewModels.Player;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private AccountPlayerManager PlayerManager => HttpContext.GetOwinContext().GetUserManager<AccountPlayerManager>();
        // GET: Player
        public ActionResult Index()
        {
            return View(PlayerManager.FindById(User.Identity.GetUserId()));
        }
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var player = await PlayerManager.FindByIdAsync(id);

            if (player == null)
            {
                return Content("Not found");
            }

            var model = new EditPlayerViewModel { Id = player.Id, Name = player.UserName };

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EditPlayerViewModel model)
        {
            var gameEngine = new GameEngine(User.Identity.GetUserId());

            if (!ModelState.IsValid) return View(model);

            var player = await PlayerManager.FindByIdAsync(model.Id);

            //var p = await CurrentPlayerProcessor.PlayerManager.FindByIdAsync(model.Id);

            if (player == null) return View(model);

            player.UserName = model.Name;

            //p.UserName = model.Name;

            var result = await PlayerManager.UpdateAsync(player);
            if (result.Succeeded)
            {
                //await CurrentPlayerProcessor.PlayerManager.UpdateAsync(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
            return View(model);
        }

        public ActionResult OutOfMoney()
        {
            return RedirectToAction("GameOver", "GamePlay");
        }
    }
}
