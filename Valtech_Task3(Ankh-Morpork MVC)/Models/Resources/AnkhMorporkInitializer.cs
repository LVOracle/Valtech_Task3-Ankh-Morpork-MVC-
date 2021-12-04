using System.Data.Entity;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.Resources
{
    public class AnkhMorporkInitializer : DropCreateDatabaseAlways<AnkhMorporkGameContext>
    {
        protected override void Seed(AnkhMorporkGameContext context)
        {
            DbSeedData.SeedData(context);
        }
    }
}