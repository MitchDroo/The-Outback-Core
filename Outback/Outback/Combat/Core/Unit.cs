namespace Outback.Combat.Core
{
    public class Unit
    {
        public string Name;
        public int Health;

        public void TakeDamage(int amount)
        {
            Health -= amount;
        }

        public void Heal(int amount)
        {
            Health += amount;
        }
    }
}