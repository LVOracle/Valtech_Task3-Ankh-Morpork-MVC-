using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Resources.Account;

[assembly: OwinStartup(typeof(Valtech_Task3_Ankh_Morpork_MVC_.Startup))]
namespace Valtech_Task3_Ankh_Morpork_MVC_
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(AccountContext.Create);
            app.CreatePerOwinContext<AccountPlayerManager>(AccountPlayerManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}