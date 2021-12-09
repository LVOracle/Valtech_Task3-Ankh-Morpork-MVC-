using System.Collections.Generic;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.IRepository;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository
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