using System.Collections.Generic;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.IRepository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Repository
{
    public class FoolsRepository : IAnkhMorporkRepository<Fools>
    {
        private readonly FoolsDbContext _context;
        public FoolsRepository(FoolsDbContext context) => _context = context;
        public IEnumerable<Fools> GetGuildMembersEnumerable => _context.FoolsTable;
    }
}