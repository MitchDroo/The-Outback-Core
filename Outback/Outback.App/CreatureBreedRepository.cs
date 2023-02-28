using System.Collections.Generic;
using Outback.Combat;

namespace Outback.App
{
    public class CreatureBreedRepository : ICreatureBreedRepository
    {
        private Dictionary<string, CreatureBreed> _breeds;

        public CreatureBreedRepository()
        {
            _breeds = new Dictionary<string, CreatureBreed>();
        }

        public CreatureBreed Get(string breedName)
        {
            return BreedExists(breedName) ? _breeds[breedName] : NoCreatureBreed.Instance;
        }

        public List<CreatureBreed> GetAll()
        {
            return new List<CreatureBreed>(_breeds.Values);
        }

        public void Add(CreatureBreed breed)
        {
            if (!BreedExists(breed.BreedName))
            {
                _breeds[breed.BreedName] = breed;
            }
        }

        public void Update(CreatureBreed breed)
        {
            if (BreedExists(breed.BreedName))
            {
                _breeds[breed.BreedName] = breed;
            }
        }

        public void Remove(CreatureBreed breed)
        {
            if (BreedExists(breed.BreedName))
            {
                _breeds.Remove(breed.BreedName);
            }
        }

        private bool BreedExists(string key)
        {
            return _breeds.ContainsKey(key);
        }
    }
}