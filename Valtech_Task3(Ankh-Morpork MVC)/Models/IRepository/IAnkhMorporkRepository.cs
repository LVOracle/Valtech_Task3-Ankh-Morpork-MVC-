using System.Collections.Generic;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.IRepository
{
    interface IAnkhMorporkRepository<T>
    {
        IEnumerable<T> GetGuildMembersEnumerable { get; }
        void Save(T member);
    }
}
