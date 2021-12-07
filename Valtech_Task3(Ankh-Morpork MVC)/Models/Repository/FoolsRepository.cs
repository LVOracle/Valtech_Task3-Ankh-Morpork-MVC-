using System.Collections.Generic;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.IRepository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository
{
    public class FoolsRepository : IAnkhMorporkRepository<Fools>
    {
        private readonly AnkhMorporkGameContext _context;
        public FoolsRepository(AnkhMorporkGameContext context) => _context = context;
        public IEnumerable<Fools> GetGuildMembersEnumerable => _context.FoolsTable;
        public void Save(Fools member)
        {
            _context.FoolsTable.Add(member);
            _context.SaveChanges();
        }
    }
}