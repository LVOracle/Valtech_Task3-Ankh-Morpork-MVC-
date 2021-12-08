using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Resources;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.ViewModels.Account;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class AccountController : Controller
    {
        private AccountPlayerManager PlayerManager =>
            HttpContext.GetOwinContext().GetUserManager<AccountPlayerManager>();

        private IAuthenticationManager AuthenticationMaaManager => HttpContext.GetOwinContext().Authentication;
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
            if (ModelState.IsValid)
            {
                var player = new Player() {UserName = model.Name};
                var result = await PlayerManager.CreateAsync(player, model.Password);
                if (result.Succeeded)
                {
                    var claim = await PlayerManager.CreateIdentityAsync(player,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationMaaManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("",error);
                    }
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
            if (ModelState.IsValid)
            {
                var player = await PlayerManager.FindAsync(model.Name, model.Password);
                if (player == null)
                {
                    ModelState.AddModelError("", "Incorrect login or password");
                }
                else
                {
                    var claim = await PlayerManager.CreateIdentityAsync(player,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationMaaManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Logout()
        {
            AuthenticationMaaManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}