using System.Collections.Generic;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.IRepository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Repository
{
    public class BeggarsRepository : IAnkhMorporkRepository<Beggars>
    {
        private readonly BeggarsDbContext _context;
        public BeggarsRepository(BeggarsDbContext context) => _context = context;
        public IEnumerable<Beggars> GetGuildMembersEnumerable => _context.BeggarsTable;
    }
}