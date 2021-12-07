using System.Collections.Generic;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.IRepository;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository
{
    public class ThievesRepository : IAnkhMorporkRepository<Thieves>
    {
        private readonly AnkhMorporkGameContext _context;
        public ThievesRepository(AnkhMorporkGameContext context) => _context = context;
        public IEnumerable<Thieves> GetGuildMembersEnumerable => _context.ThievesTable;
        public void Save(Thieves member)
        {
            _context.ThievesTable.Add(member);
            _context.SaveChanges();
        }
    }
}