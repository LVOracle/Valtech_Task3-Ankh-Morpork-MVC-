namespace Valtech_Task3_Ankh_Morpork_MVC_.Resources
{
    public class FoolsGuild : Guild
    {
        public FoolsGuild() : base("Fool", "DICO, DICO, DICO (Say Say Say)"){}
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}