using System.Collections.Generic;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.IRepository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Repository
{
    public class AssassinsRepository : IAnkhMorporkRepository<Assassins>
    {
        private readonly AnkhMorporkGameContext _context;
        public AssassinsRepository(AnkhMorporkGameContext context) => _context = context;
        public IEnumerable<Assassins> GetGuildMembersEnumerable => _context.AssassinsTable;
        public void Save(Assassins member)
        {
            _context.AssassinsTable.Add(member);
            _context.SaveChanges();
        }
    }
}