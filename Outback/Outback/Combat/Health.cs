using System;

namespace Outback.Combat
{
    /// <summary>
    ///     A character's health.
    /// </summary>
    public class Health
    {
        public Health(int currentHealth, int maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }

        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; }

        public bool IsDead => CurrentHealth == 0;
        public event Action<int> OnHealthUpdated;

        /// <summary>
        ///     Deal a certain amount of damage
        /// </summary>
        /// <param name="amount"></param>
        public void TakeDamage(int amount)
        {
            CurrentHealth = Math.Max(0, CurrentHealth - amount);
            OnHealthUpdated?.Invoke(CurrentHealth);
        }

        /// <summary>
        ///     Heal a certain amount of damage
        /// </summary>
        /// <param name="amount"></param>
        public void Heal(int amount)
        {
            CurrentHealth = Math.Min(MaxHealth, CurrentHealth + amount);
            OnHealthUpdated?.Invoke(CurrentHealth);
        }
    }
}