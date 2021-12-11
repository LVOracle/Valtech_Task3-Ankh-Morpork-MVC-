namespace Valtech_Task3_Ankh_Morpork_MVC_.Models
{
    public class Fools
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TakeMoney { get; set; }
        public string ImageName { get; set; }
        public override string ToString() { return Name; }
    }
}