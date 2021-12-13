using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Resources;
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
            return View(PlayerManager.Users.ToList());
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
            if (ModelState.IsValid)
            {
                var player = await PlayerManager.FindByIdAsync(model.Id);
                if (player != null)
                {
                    player.UserName = model.Name;

                    var result = await PlayerManager.UpdateAsync(player);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error);
                        }
                    }
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var player = await PlayerManager.FindByIdAsync(id);
            if (player != null)
            {
                IdentityResult result = await PlayerManager.DeleteAsync(player);
            }
            else
            {
                return Content("Not found");
            }
            return RedirectToAction("Index");
        }

        public ActionResult OutOfMoney()
        {
            return RedirectToAction("GameOver", "GamePlay");
        }
    }
}
