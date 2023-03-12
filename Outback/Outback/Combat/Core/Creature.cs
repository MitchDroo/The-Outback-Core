using System;

namespace Outback.Combat.Core
{
    [Serializable]
    public class Creature
    {
        private CreatureBreed _breed;
        private Health _health;

        public Creature(CreatureBreed breed)
        {
            _breed = breed ?? NoCreatureBreed.Instance;
            _health = new Health(_breed.StartingHealth, _breed.StartingHealth);
        }

        public CreatureBreed Breed => _breed;
        public Health Health => _health;
    }
}