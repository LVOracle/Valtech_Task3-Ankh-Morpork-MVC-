using Microsoft.AspNet.Identity.EntityFramework;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models
{
    public class Player : IdentityUser
    {
        public decimal Money { get; set; }
        public bool IsKilled { get; set; }
        public int AmountOfGames { get; set; } = 0;
        public int AmountOfBeer { get; set; } = 1;
        public bool HaveBeer { get; set; } = true;
        public int Step { get; set; } = 0;
        public int MaxAmountOfSteps { get; set; } = 0;
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
        public void IncrementStep()
        {
            ++Step;
        }

        public bool BuyBeer(int number)
        {
            if (AmountOfBeer >= 2 || number > 2) return false;
            AmountOfBeer += number;
            return true;
        }
        public override string ToString() { return UserName; }
    }
}