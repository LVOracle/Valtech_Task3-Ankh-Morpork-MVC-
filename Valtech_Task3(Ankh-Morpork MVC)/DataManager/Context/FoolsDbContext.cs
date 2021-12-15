using System.Data.Entity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context
{
    public class FoolsDbContext : DbContext
    {
        public DbSet<Fools> FoolsTable { get; set; }

        public FoolsDbContext() : base("AnkhMorporkGameDB") { }
        public static FoolsDbContext Create()
        {
            return new FoolsDbContext();
        }
    }
}