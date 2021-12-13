using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Resources
{
    public class AccountPlayerManager : UserManager<Player>
    {
        public AccountPlayerManager(IUserStore<Player> store) : base(store) { }

        public static AccountPlayerManager Create(IdentityFactoryOptions<AccountPlayerManager> options,
            IOwinContext context)
        {
            AccountContext db = context.Get<AccountContext>();
            AccountPlayerManager manager = new AccountPlayerManager(new UserStore<Player>(db));
            return manager;
        }
    }
}