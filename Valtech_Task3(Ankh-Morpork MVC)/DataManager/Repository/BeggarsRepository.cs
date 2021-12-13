using System.Collections.Generic;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.IRepository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Repository
{
    public class BeggarsRepository : IAnkhMorporkRepository<Beggars>
    {
        private readonly AnkhMorporkGameContext _context;
        public BeggarsRepository(AnkhMorporkGameContext context) => _context = context;
        public IEnumerable<Beggars> GetGuildMembersEnumerable => _context.BeggarsTable;
        public void Save(Beggars member)
        {
            _context.BeggarsTable.Add(member);
            _context.SaveChanges();
        }
    }
}