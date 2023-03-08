using System;
using System.Collections.Generic;
using Outback.Combat.Moves;

namespace Outback.Combat
{
    [Serializable]
    public class CreatureBreed
    {
        public string BreedName;
        public int StartingHealth;
        public int Attack;
        public int Defense;
        public List<ICombatMove> Moves;
    }
}