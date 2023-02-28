using System.Collections.Generic;
using Outback.Combat;

namespace Outback.App
{
    public class Game
    {
        private ICreatureBreedRepository _breedRepository;
        private ICreatureSpawner _spawner;

        public Game()
        {
            _breedRepository = new CreatureBreedRepository();
            _spawner = new ConsoleCreatureSpawner();
            
            Bootstrap();
        }

        public void Run()
        {
            var creature = new Creature(_breedRepository.Get("Koala"));
            _spawner.SpawnCreature(creature, 0);
        }

        private void Bootstrap()
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