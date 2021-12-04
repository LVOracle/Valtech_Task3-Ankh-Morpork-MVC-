using System.Collections.Generic;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.IRepository
{
    interface IAnkhMorporkRepository
    {
        IEnumerable<Assassins> GetAssassinsEnumerable { get; }
        IEnumerable<Beggars> GetBeggarsEnumerable { get; }
        IEnumerable<Fools> GetFoolsEnumerable { get; }
        IEnumerable<Thieves> GetThievesEnumerable { get; }
    }
}
