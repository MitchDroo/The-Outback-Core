using System.Collections.Generic;

namespace Outback
{
    public interface IDialogueRepository
    {
        Dialogue FindById(long id);
        List<Dialogue> FindAll();
        void Add(Dialogue dialogue);
        void Remove(Dialogue dialogue);
        void Update(Dialogue dialogue);
    }
}