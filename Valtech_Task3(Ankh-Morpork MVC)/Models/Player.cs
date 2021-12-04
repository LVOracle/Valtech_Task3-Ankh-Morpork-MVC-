namespace Valtech_Task3_Ankh_Morpork_MVC_.Models
{
    public class Player
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public bool IsKilled { get; set; }
        public Player(string name)
        {
            Name = name;
            Money = 100m;
            IsKilled = false;
        }
        public override string ToString() { return Name; }
    }
}