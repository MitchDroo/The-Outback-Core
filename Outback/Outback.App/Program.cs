using Outback.Combat;

namespace Outback.App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var spawner = new ConsoleCreatureSpawner();
            var breed = new CreatureBreed()
            {
                BreedName = "Test"
            };
            var creature = new Creature(breed);
            spawner.SpawnCreature(creature, 0);
        }
    }
}