using System;
using Outback.Combat;

namespace Outback.App
{
    public class ConsoleCreatureSpawner : ICreatureSpawner
    {
        public void SpawnCreature(Creature creature, int position)
        {
            Console.WriteLine($"Spawning {creature.Breed.BreedName}");
        }
    }
}