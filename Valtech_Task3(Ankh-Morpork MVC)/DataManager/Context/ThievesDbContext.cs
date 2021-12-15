using System.Data.Entity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context
{
    public class ThievesDbContext : DbContext
    {
        public DbSet<Thieves> ThievesTable { get; set; }
        public ThievesDbContext() : base("AnkhMorporkGameDB") { }
        public static ThievesDbContext Create()
        {
            return new ThievesDbContext();
        }
    }
}