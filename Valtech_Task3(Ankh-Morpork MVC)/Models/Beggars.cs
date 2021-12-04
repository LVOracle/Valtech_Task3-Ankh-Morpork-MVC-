namespace Valtech_Task3_Ankh_Morpork_MVC_.Models
{
    public class Beggars
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal GiveMoney { get; set; }
        public override string ToString() { return Name; }
    }
}