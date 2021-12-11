using System.Collections.Generic;
using Valtech_Task3_Ankh_Morpork_MVC_.Models.Context;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.Resources
{
    public class DbSeedData
    {
        public static void SeedData(AnkhMorporkGameContext context)
        {
            context.AssassinsTable.AddRange(new List<Assassins>
            {
                new Assassins { Name = "Knife", MinRange = 15, MaxRange = 30, IsOccupied = false, ImageName = "1.jpg"},
                new Assassins { Name = "Sword", MinRange = 10,  MaxRange = 20, IsOccupied = true,ImageName = "2.jpg"},
                new Assassins { Name = "Star", MinRange = 7, MaxRange = 12, IsOccupied = false,ImageName = "3.jpg"},
                new Assassins { Name = "Axe", MinRange = 15, MaxRange = 19, IsOccupied = true,ImageName = "4.png"},
                new Assassins { Name = "Gun", MinRange = 4, MaxRange = 12, IsOccupied = true,ImageName = "5.jpg"},
                new Assassins { Name = "Ranger", MinRange = 29, MaxRange = 45, IsOccupied = false,ImageName = "6.jfif"},
                new Assassins { Name = "Dodick", MinRange = 15, MaxRange = 22, IsOccupied = false,ImageName = "7.jpg"},
                new Assassins { Name = "RedBorsh", MinRange = 18, MaxRange = 27, IsOccupied = true,ImageName = "8.jfif"}
            });

            context.BeggarsTable.AddRange(new List<Beggars>
            {
                new Beggars { Name = "Twitcher", GiveMoney = 3, ImageName = "7.jfif"},
                new Beggars { Name = "Drooler", GiveMoney = 2, ImageName = "9.jfif"},
                new Beggars { Name = "Dribbler", GiveMoney = 1,ImageName = "2.jfif"},
                new Beggars { Name = "Mumbler", GiveMoney = 1,ImageName = "10.jfif"},
                new Beggars { Name = "Mutterer", GiveMoney = 0.9m,ImageName = "6.jpg"},
                new Beggars { Name = "Walking-Along-Shouters", GiveMoney = 0.8m,ImageName = "4.jfif"},
                new Beggars { Name = "Demanders of a Chip", GiveMoney = 0.6m,ImageName = "3.jfif"},
                new Beggars { Name = "People Who Call Other People Jimmy", GiveMoney = 0.5m,ImageName = "8.jpg"},
                new Beggars { Name = "People Who Need Eightpence For A Meal", GiveMoney = 0.08m,ImageName = "5.jpg"},
                new Beggars { Name = "People Who Need Tuppence For A Cup Of Tea", GiveMoney = 0.02m,ImageName = "1.jpg"},
                new Beggars { Name = "People With Placards Saying \"Why lie? I need a beer.\"", GiveMoney = 0,ImageName = "11.jpg"},
            });

            context.FoolsTable.AddRange(new List<Fools>
            {
                new Fools { Name = "Muggins", TakeMoney = 0.5m, ImageName = "3.jpg"},
                new Fools { Name = "Gull", TakeMoney = 1,ImageName = "9.jpg"},
                new Fools { Name = "Dupe", TakeMoney = 2,ImageName = "8.jpg"},
                new Fools { Name = "Butt", TakeMoney = 3,ImageName = "7.jpg"},
                new Fools { Name = "Fool", TakeMoney = 5,ImageName = "2.jfif"},
                new Fools { Name = "Tomfool", TakeMoney = 6,ImageName = "6.jpg"},
                new Fools { Name = "Stupid fool", TakeMoney = 7,ImageName = "5.jpg"},
                new Fools { Name = "Arch fool", TakeMoney = 8,ImageName = "4.jpg"},
                new Fools { Name = "Complete fool", TakeMoney = 10,ImageName = "1.png"},
            });

            context.ThievesTable.AddRange(new List<Thieves>
            {
                new Thieves(){Name = "Brandy",ImageName = "1.jpg"},
                new Thieves(){Name = "Stocky",ImageName = "2.jpg"},
                new Thieves(){Name = "Falcon",ImageName = "3.jpg"}
            });

            context.SaveChanges();
        }
    }
}