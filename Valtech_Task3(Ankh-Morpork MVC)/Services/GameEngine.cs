using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Guilds;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Services
{
    public class GameEngine
    {
        private CurrentPlayerProcessor _currentPlayerProcessor;
        public static decimal MoneyChecker { get; set; }
        public GameEngine(string id)
        {
            _currentPlayerProcessor = new CurrentPlayerProcessor();
            
            CurrentPlayerProcessor.CurrentPlayer = CurrentPlayerProcessor.GetCurrentPlayer(id);
        }

        public void StartInitialization()
        {
            ++CurrentPlayerProcessor.CurrentPlayer.AmountOfGames;

            CurrentPlayerProcessor.CurrentPlayer.Money = 100m;

            CurrentPlayerProcessor.CurrentPlayer.AmountOfBeer = 1;

            if (CurrentPlayerProcessor.CurrentPlayer.Step > CurrentPlayerProcessor.CurrentPlayer.MaxAmountOfSteps)
                CurrentPlayerProcessor.CurrentPlayer.MaxAmountOfSteps = CurrentPlayerProcessor.CurrentPlayer.Step;

            CurrentPlayerProcessor.CurrentPlayer.Step = 0;

            CurrentPlayerProcessor.CurrentPlayer.HasBeer = true;

            CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);

            ThievesGuild.TheftLimit = 6;
        }

        public void Step()
        {
            CurrentPlayerProcessor.CurrentPlayer.IncrementStep();
            CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);
        }
    }
}