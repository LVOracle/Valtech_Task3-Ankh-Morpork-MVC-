namespace Valtech_Task3_Ankh_Morpork_MVC_.Resources
{
    public class BeggarsGuild : Guild
    {
        public BeggarsGuild() : base("Beggar","MONETA SVPERVACANEA, MAGISTER (Coin Svpervacanea, Magister)"){}
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}