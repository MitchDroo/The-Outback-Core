using System.Collections.Generic;
using Outback.Combat.Moves;

namespace Outback.Combat
{
    public class NoCreatureBreed : CreatureBreed
    {
        private static NoCreatureBreed _instance;
        public static NoCreatureBreed Instance => _instance ??= CreateInstance();

        private static NoCreatureBreed CreateInstance()
        {
            return new NoCreatureBreed
            {
                BreedName = "No Name",
                StartingHealth = 0,
                Attack = 0,
                Defense = 0,
                Moves = new List<ICombatMove>()
            };
        }
    }
}