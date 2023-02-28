using System.Collections.Generic;

namespace Outback.Combat
{
    public interface ICreatureBreedRepository
    {
        CreatureBreed Get(string breedName);
        List<CreatureBreed> GetAll();
        void Add(CreatureBreed breed);
        void Update(CreatureBreed breed);
        void Remove(CreatureBreed breed);
    }
}