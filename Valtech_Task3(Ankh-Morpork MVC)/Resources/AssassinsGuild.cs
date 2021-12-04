namespace Valtech_Task3_Ankh_Morpork_MVC_.Resources
{
    public class AssassinsGuild : Guild
    {
        private decimal Pay { get; set; }
        public AssassinsGuild() : base("Assassin", "NIL VOLVPIT, SINE LVCRE (No Pay No Fun)"){}
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}