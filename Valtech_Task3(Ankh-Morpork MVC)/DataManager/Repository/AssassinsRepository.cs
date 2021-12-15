using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.IRepository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Repository
{
    public class AssassinsRepository : IAnkhMorporkRepository<Assassins>
    {
        private readonly AssassinsDbContext _context;
        public AssassinsRepository(AssassinsDbContext context) => _context = context;
        public IEnumerable<Assassins> GetGuildMembersEnumerable => _context.AssassinsTable;
        public void Update(Assassins member)
        {   
            _context.AssassinsTable.AddOrUpdate(member);
            _context.SaveChanges();
        }
    }
}