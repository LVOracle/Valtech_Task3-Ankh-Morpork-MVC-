namespace Valtech_Task3_Ankh_Morpork_MVC_.Resources
{
    public abstract class Guild
    {
        protected string Name { get; }
        protected string Slogan { get; }
        protected Guild(string name, string slogan)
        {
            Name = name;
            Slogan = slogan;
        }
        public static Guild[] GetAllGuilds()
        {
            var allGuilds = new Guild[]
            {
                new AssassinsGuild(), new BeggarsGuild(), new FoolsGuild(), new ThievesGuild()
            };
            return allGuilds;
        }
    }
}