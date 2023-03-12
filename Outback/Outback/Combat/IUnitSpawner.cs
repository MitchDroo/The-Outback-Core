using Outback.Combat.Core;

namespace Outback.Combat
{
    public interface IUnitSpawner
    {
        void SpawnUnit(Unit unit, int position);
    }
}