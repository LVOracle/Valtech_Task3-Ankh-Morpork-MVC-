using Microsoft.AspNet.Identity.EntityFramework;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.Context
{
    public class AccountContext : IdentityDbContext<Player>
    {
        public AccountContext() : base("AccountContext", throwIfV1Schema:false) {}

        public static AccountContext Create()
        {
            return new AccountContext();
        }
    }
}