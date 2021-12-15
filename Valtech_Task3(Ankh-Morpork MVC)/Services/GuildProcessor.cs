using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Valtech_Task3_Ankh_Morpork_MVC_.Guilds;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Services
{
    public static class GuildProcessor
    {
        public static string GetRandomGuild()
        {
            int randomNumberOfTheGuild;
            do
            {
                randomNumberOfTheGuild = RandomGenerate.GetRandom(0, GuildProcessor.GetAllGuilds().ToList().Count);
            } while (ThievesGuild.TheftLimit == 0 && randomNumberOfTheGuild == 3);
            var guildName = GuildProcessor.GetAllGuilds().ToList().ElementAt(randomNumberOfTheGuild).Name;
            return guildName;
        }
        private static IEnumerable<Type> GetAllGuilds()
        {
            var baseType = typeof(Guild);
            var allGuilds = Assembly.GetAssembly(baseType).GetTypes().Where(type => type.IsSubclassOf(baseType));
            return allGuilds;
        }
    }
}