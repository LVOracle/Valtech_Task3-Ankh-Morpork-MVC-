using System.Collections.Generic;
using System.Linq;
using Valtech_Task3_Ankh_Morpork_MVC_.DataManager.Repository;
using Valtech_Task3_Ankh_Morpork_MVC_.Models;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Guilds
{
    public class AssassinsGuild : Guild
    {
        public AssassinsGuild() : base("Assassin", "NIL VOLVPIT, SINE LVCRE (No Pay No Fun)") { }

        public static void ChangeOccupiedAssassins(AssassinsRepository _assassinsRepository, List<Assassins> listOfAvailableAssassins)
        {
            var listOfNotAvailableAssassins =
                _assassinsRepository.GetGuildMembersEnumerable.Where(assassin => assassin.IsOccupied == true).ToList();

            var freeAssassin = listOfNotAvailableAssassins.ElementAtOrDefault(0);

            freeAssassin.IsOccupied = false;

            _assassinsRepository.Update(freeAssassin);

            var occupiedAssassin = listOfAvailableAssassins.ElementAt(0);

            occupiedAssassin.IsOccupied = true;

            _assassinsRepository.Update(occupiedAssassin);
        }
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}