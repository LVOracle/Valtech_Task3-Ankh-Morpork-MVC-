namespace Valtech_Task3_Ankh_Morpork_MVC_.Guilds
{
    public abstract class Guild
    {
        public string Name { get; }
        public string Slogan { get; }
        protected Guild(string name, string slogan)
        {
            Name = name;
            Slogan = slogan;
        }
    }
}