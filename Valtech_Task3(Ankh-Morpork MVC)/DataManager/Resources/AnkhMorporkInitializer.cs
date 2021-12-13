using System.Data.Entity;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Resources
{
    public class AnkhMorporkInitializer : DropCreateDatabaseAlways<AnkhMorporkGameContext>
    {
        protected override void Seed(AnkhMorporkGameContext context)
        {
            DbSeedData.SeedData(context);
        }
    }
}