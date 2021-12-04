using System.Data.Entity;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.Resources
{
    public class AnkhMorporkGameContext : DbContext
    {
        public DbSet<Assassins> AssassinsTable { get; set; }
        public DbSet<Beggars> BeggarsTable { get; set; }
        public DbSet<Fools> FoolsTable { get; set; }
        public DbSet<Thieves> ThievesTable { get; set; }
    }
}