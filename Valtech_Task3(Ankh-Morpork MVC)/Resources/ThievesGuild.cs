namespace Valtech_Task3_Ankh_Morpork_MVC_.Resources
{
    public class ThievesGuild : Guild
    {
        public static byte TheftLimit { get; set; } = 6;
        public static byte MoneySteel { get; set; } = 10;
        public ThievesGuild() : base("Thieves","ACVTVS ID VERBERAT (Whistle Fast)"){}
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }

    }
}