using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Services
{
    public class GameController
    {
        private CurrentPlayerProcessor _currentPlayerProcessor;
        public decimal MoneyChecker { get; set; }
        public GameController(string id)
        {
            _currentPlayerProcessor = new CurrentPlayerProcessor();
            
            CurrentPlayerProcessor.CurrentPlayer = CurrentPlayerProcessor.GetCurrentPlayer(id);

            MoneyChecker = CurrentPlayerProcessor.CurrentPlayer.Money;
        }

        public void GameOver()
        {
            ++CurrentPlayerProcessor.CurrentPlayer.AmountOfGames;

            CurrentPlayerProcessor.CurrentPlayer.Money = 100m;

            CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);

            ThievesGuild.TheftLimit = 6;
        }
    }
}