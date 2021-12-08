using System.Linq;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Resources
{
    public static class GuildProcessor
    {
        public static string GetRandomGuild()
        {
            var randomNumberOfTheGuild = RandomGenerate.GetRandom(0, GuildProcessor.GetAllGuilds().Length);
            var guildName = GuildProcessor.GetAllGuilds().ElementAt(randomNumberOfTheGuild).GetType().Name;
            return guildName;
        }
        private static Guild[] GetAllGuilds()
        {
            var allGuilds = new Guild[]
            {
                new AssassinsGuild(), new BeggarsGuild(), new FoolsGuild(), new ThievesGuild()
            };
            return allGuilds;
        }
    }
}