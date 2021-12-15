﻿using System.Dynamic;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Guilds
{
    public abstract class Guild
    {
        public string Name { get; }
        public string Slogan { get; }
        protected Guild(string name, string slogan)
        {
            Name = name;
            Slogan = slogan;
        }

        //public T GetMember(int lenth)
        //{
        //    var memberRandomNumber = RandomGenerate.GetRandom(0, lenth);
        //    var thieve = thievesRepository.GetGuildMembersEnumerable.ElementAt(thieveRandomNumber);
        //    return thieve;
        //}
    }
}