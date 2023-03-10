using System.Collections.Generic;
using System.Linq;

namespace Outback.App
{
    public class DialogueRepository : IDialogueRepository
    {
        private Dictionary<long, Dialogue> _dialogues;

        public DialogueRepository()
        {
            _dialogues = new Dictionary<long, Dialogue>();
        }

        public DialogueRepository(Dictionary<long, Dialogue> dialogues)
        {
            _dialogues = dialogues;
        }

        public Dialogue FindById(long id)
        {
            return _dialogues[id];
        }

        public List<Dialogue> FindAll()
        {
            return _dialogues.Values.ToList();
        }

        public void Add(Dialogue dialogue)
        {
            _dialogues.Add(dialogue.Id, dialogue);
        }

        public void Remove(Dialogue dialogue)
        {
            _dialogues.Remove(dialogue.Id);
        }

        public void Update(Dialogue dialogue)
        {
            _dialogues[dialogue.Id] = dialogue;
        }
    }
}