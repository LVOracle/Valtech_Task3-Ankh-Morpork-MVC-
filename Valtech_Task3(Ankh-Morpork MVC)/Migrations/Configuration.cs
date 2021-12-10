namespace Valtech_Task3_Ankh_Morpork_MVC_.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Valtech_Task3_Ankh_Morpork_MVC_.Models.Context.AccountContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Valtech_Task3_Ankh_Morpork_MVC_.Models.Context.AccountContext";
        }
    }
}
