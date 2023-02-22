namespace Outback.App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var spawner = new ConsoleCreatureSpawner();
            var creature = new Creature()
            {
                Name = "Test"
            };
            spawner.SpawnCreature(creature, 0);
        }
    }
}