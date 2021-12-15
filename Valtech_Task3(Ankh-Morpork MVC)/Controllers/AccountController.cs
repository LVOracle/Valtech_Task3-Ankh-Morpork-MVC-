using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Resources;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.ViewModels.Account;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class AccountController : Controller
    {
        private AccountPlayerManager PlayerManager =>
            HttpContext.GetOwinContext().GetUserManager<AccountPlayerManager>();

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
        // GET: Account
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var player = new Player() {UserName = model.Name};
            var result = await PlayerManager.CreateAsync(player, model.Password);
            if (result.Succeeded)
            {
                var claim = await PlayerManager.CreateIdentityAsync(player,
                    DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true
                }, claim);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error);
                }
            }

            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var player = await PlayerManager.FindAsync(model.Name, model.Password);
            if (player == null)
            {
                ModelState.AddModelError("", "Incorrect login or password");
            }
            else
            {
                var claim = await PlayerManager.CreateIdentityAsync(player,
                    DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true
                }, claim);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}