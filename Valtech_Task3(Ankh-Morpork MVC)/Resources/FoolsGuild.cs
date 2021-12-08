﻿using System.Linq;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Resources
{
    public class FoolsGuild : Guild
    {
        private static readonly FoolsRepository FoolsRepository =
            new FoolsRepository(AnkhMorporkGameContext.Create());
        public FoolsGuild() : base("Fool", "DICO, DICO, DICO (Say Say Say)"){}
        public static Fools GetFool()
        {
            var foolRandomNumber = RandomGenerate.GetRandom(0, FoolsRepository.GetGuildMembersEnumerable.Count());
            var fool = FoolsRepository.GetGuildMembersEnumerable.ElementAt(foolRandomNumber);
            return fool;
        }
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}