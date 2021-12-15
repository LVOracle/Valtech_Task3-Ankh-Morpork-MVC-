using System.Collections.Generic;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.IRepository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Repository
{
    public class ThievesRepository : IAnkhMorporkRepository<Thieves>
    {
        private readonly ThievesDbContext _context;
        public ThievesRepository(ThievesDbContext context) => _context = context;
        public IEnumerable<Thieves> GetGuildMembersEnumerable => _context.ThievesTable;
    }
}