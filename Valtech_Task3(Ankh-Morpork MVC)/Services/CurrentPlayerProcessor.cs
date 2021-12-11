using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Services
{
    public class CurrentPlayerProcessor
    {
        public static UserManager<Player> PlayerManager { get; private set; }
        public static Player CurrentPlayer { get; set; }

        public CurrentPlayerProcessor()
        {
            PlayerManager = new UserManager<Models.Player>(new UserStore<Models.Player>(new AccountContext()));
        }

        public static Player GetCurrentPlayer(string id)
        {
            var player = PlayerManager.FindById(id);
            return player;
        }
        public static string PlayerBalanceTextVariant(decimal money)
        {
            var integerValue = Math.Floor(money);
            var floatValue = (money - integerValue) * 100m;
            return floatValue == 0 ? $"{integerValue} AM$" : $"{integerValue} AM$ {Convert.ToInt32(floatValue)} coins";
        }
    }
}