using System.Collections.Generic;
using Outback.Combat;

namespace Outback.App
{
    internal class Program
    {
        private static ICreatureBreedRepository _breedRepository;

        public static void Main(string[] args)
        {
            _breedRepository = new CreatureBreedRepository();

            Bootstrap();

            var spawner = new ConsoleCreatureSpawner();
            var creature = new Creature(_breedRepository.Get("Koala"));
            spawner.SpawnCreature(creature, 0);
        }

        private static void Bootstrap()
        {
            _breedRepository.Add(new CreatureBreed
            {
                BreedName = "Kangaroo",
                StartingHealth = 10,
                Attack = 7,
                Defense = 5,
                Moves = new List<ICombatMove>()
            });

            _breedRepository.Add(new CreatureBreed
            {
                BreedName = "Koala",
                StartingHealth = 5,
                Attack = 1,
                Defense = 3,
                Moves = new List<ICombatMove>()
            });

            _breedRepository.Add(new CreatureBreed()
            {
                BreedName = "Magpie",
                StartingHealth = 5,
                Attack = 5,
                Defense = 3,
                Moves = new List<ICombatMove>()
            });
        }
    }
}