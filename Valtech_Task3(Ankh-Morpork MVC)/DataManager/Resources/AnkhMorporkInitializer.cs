using System.Data.Entity;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Resources
{
    public class AnkhMorporkInitializer : DropCreateDatabaseAlways<ContextViewModel>
    {
        protected override void Seed(ContextViewModel context)
        {
            DbSeedData.SeedData(context.AssassinsDb,context.BeggarsDb,context.FoolsDb,context.ThievesDb);
        }
    }
}