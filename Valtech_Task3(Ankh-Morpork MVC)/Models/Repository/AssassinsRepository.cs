using System.Collections.Generic;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.IRepository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository
{
    public class AssassinsRepository : IAnkhMorporkRepository<Assassins>
    {
        private readonly AnkhMorporkGameContext _context;
        public AssassinsRepository(AnkhMorporkGameContext context) => _context = context;
        public IEnumerable<Assassins> GetAssassinsEnumerable => _context.AssassinsTable;
        public IEnumerable<Assassins> GetGuildMembersEnumerable => _context.AssassinsTable;
        public void Save(Assassins member)
        {
            _context.AssassinsTable.Add(member);
            _context.SaveChanges();
        }
    }
}