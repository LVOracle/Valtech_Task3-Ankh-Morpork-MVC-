using System.Data.Entity;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context
{
    public class ContextViewModel : DbContext
    {
        public AssassinsDbContext AssassinsDb { get; set; }
        public BeggarsDbContext BeggarsDb { get; set; }
        public FoolsDbContext FoolsDb { get; set; }
        public ThievesDbContext ThievesDb { get; set; }

        public ContextViewModel()
        {
            AssassinsDb = new AssassinsDbContext();
            BeggarsDb = new BeggarsDbContext();
            FoolsDb = new FoolsDbContext();
            ThievesDb = new ThievesDbContext();
        }
    }
}