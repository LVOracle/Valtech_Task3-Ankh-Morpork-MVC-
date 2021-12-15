using System.Collections.Generic;

namespace Valtech_Task3_Ankh_Morpork_MVC_.DataManager.IRepository
{
    public interface IAnkhMorporkRepository<T>
    {
        IEnumerable<T> GetGuildMembersEnumerable { get; }
    }
}
