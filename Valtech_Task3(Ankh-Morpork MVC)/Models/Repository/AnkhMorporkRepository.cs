using System.Collections.Generic;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.IRepository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository
{
    public class AnkhMorporkRepository : IAnkhMorporkRepository
    {
        private readonly AnkhMorporkGameContext _context;
        public AnkhMorporkRepository(AnkhMorporkGameContext context) => _context = context;
        public IEnumerable<Assassins> GetAssassinsEnumerable => _context.AssassinsTable;
        public IEnumerable<Beggars> GetBeggarsEnumerable => _context.BeggarsTable;
        public IEnumerable<Fools> GetFoolsEnumerable => _context.FoolsTable;
        public IEnumerable<Thieves> GetThievesEnumerable => _context.ThievesTable;
    }
}