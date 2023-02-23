using System;

namespace Outback.Combat
{
    [Serializable]
    public class Creature
    {
        private CreatureBreed _breed;

        public Creature(CreatureBreed breed)
        {
            _breed = breed ?? NoCreatureBreed.Instance;
        }

        public CreatureBreed Breed => _breed;
    }
}