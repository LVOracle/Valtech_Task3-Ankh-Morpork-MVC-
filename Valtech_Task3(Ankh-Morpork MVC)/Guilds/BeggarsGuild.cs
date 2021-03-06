using System.Linq;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Guilds
{
    public class BeggarsGuild : Guild
    {
        private static readonly BeggarsRepository BeggarsRepository =
            new BeggarsRepository(BeggarsDbContext.Create());
        public BeggarsGuild() : base("Beggar","MONETA SVPERVACANEA, MAGISTER (Coin Svpervacanea, Magister)"){}
        public static Beggars GetBeggar()
        {
            var beggarRandomNumber = RandomGenerate.GetRandom(0, BeggarsRepository.GetGuildMembersEnumerable.Count());
            var beggar = BeggarsRepository.GetGuildMembersEnumerable.ElementAt(beggarRandomNumber);
            return beggar;
        }
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}