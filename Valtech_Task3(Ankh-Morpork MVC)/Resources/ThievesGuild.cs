using System.Linq;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Resources
{
    public class ThievesGuild : Guild
    {
        private static readonly ThievesRepository thievesRepository =
            new ThievesRepository(AnkhMorporkGameContext.Create());
        public static byte TheftLimit { get; set; } = 6;
        public static decimal MoneySteel { get; set; } = 10m;
        public ThievesGuild() : base("Thieves","ACVTVS ID VERBERAT (Whistle Fast)"){}
        public static Thieves GetThieve()
        {
            var thieveRandomNumber = RandomGenerate.GetRandom(0, thievesRepository.GetGuildMembersEnumerable.Count());
            var thieve = thievesRepository.GetGuildMembersEnumerable.ElementAt(thieveRandomNumber);
            return thieve;
        }
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }

    }
}