using System.Data.Entity;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context
{
    public class BeggarsDbContext : DbContext
    {
        public DbSet<Beggars> BeggarsTable { get; set; }

        public BeggarsDbContext() : base("AnkhMorporkGameDB") { }
        public static BeggarsDbContext Create()
        {
            return new BeggarsDbContext();
        }
    }
}