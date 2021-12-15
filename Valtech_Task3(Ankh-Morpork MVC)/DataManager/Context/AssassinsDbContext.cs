using System.Data.Entity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context
{
    public class AssassinsDbContext : DbContext
    {
        public DbSet<Assassins> AssassinsTable { get; set; }
        public AssassinsDbContext() : base("AnkhMorporkGameDB") { }
        public static AssassinsDbContext Create()
        {
            return new AssassinsDbContext();
        }
    }
}