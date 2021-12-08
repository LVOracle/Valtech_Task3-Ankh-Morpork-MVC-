using System;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Services
{
    public static class RandomGenerate
    {
        private static readonly Random Random = new Random();
        public static int GetRandom(int start, int finish)
        {
            var number = Random.Next(start, finish);
            return number;
        }
    }
}