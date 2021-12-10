using Microsoft.AspNet.Identity.EntityFramework;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models
{
    public class Player : IdentityUser
    {
        public decimal Money { get; set; }
        public bool IsKilled { get; set; }
        public int AmountOfGames { get; set; } = 0;
        public Player()
        {
            Money = 100m;
            IsKilled = false;
        }
        public void LoseMoney(decimal money)
        {
            Money -= money;
        }
        public void EarnMoney(decimal money)
        {
            Money += money;
        }
        public override string ToString() { return UserName; }
    }
}