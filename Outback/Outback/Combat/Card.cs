using System;

namespace Outback.Combat
{
    [Serializable]
    public class Card
    {
        public string Description;
        public string Name;

        public Card(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}