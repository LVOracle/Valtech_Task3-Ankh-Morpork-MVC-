using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Resources;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Services
{
    public class GameController
    {
        public bool IsGameOver { get; set; } = false;
        private CurrentPlayerProcessor _currentPlayerProcessor;
        public GameController(string id)
        {
            _currentPlayerProcessor = new CurrentPlayerProcessor();
            CurrentPlayerProcessor.CurrentPlayer = CurrentPlayerProcessor.GetCurrentPlayer(id);
            CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);
            if (!IsGameOver)
            {
                ThievesGuild.TheftLimit = 6;
                CurrentPlayerProcessor.CurrentPlayer.Money = 100m;
            }
        }
    }
}