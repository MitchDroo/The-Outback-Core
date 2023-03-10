using System.Collections.Generic;
using System.Linq;

namespace Outback.App
{
    public class DialogueSpeakerRepository : IDialogueSpeakerRepository
    {
        private readonly Dictionary<string, DialogueSpeaker> _dialogueSpeakers;

        public DialogueSpeakerRepository()
        {
            _dialogueSpeakers = new Dictionary<string, DialogueSpeaker>();
        }

        public DialogueSpeakerRepository(Dictionary<string, DialogueSpeaker> dialogueSpeakers)
        {
            _dialogueSpeakers = dialogueSpeakers;
        }

        public DialogueSpeaker GetBySpeakerName(string speakerName)
        {
            return _dialogueSpeakers[speakerName];
        }

        public List<DialogueSpeaker> GetAll()
        {
            return _dialogueSpeakers.Values.ToList();
        }

        public void Add(DialogueSpeaker dialogueSpeaker)
        {
            _dialogueSpeakers.Add(dialogueSpeaker.SpeakerName, dialogueSpeaker);
        }

        public void Remove(DialogueSpeaker dialogueSpeaker)
        {
            _dialogueSpeakers.Remove(dialogueSpeaker.SpeakerName);
        }

        public void Update(DialogueSpeaker dialogueSpeaker)
        {
            _dialogueSpeakers[dialogueSpeaker.SpeakerName] = dialogueSpeaker;
        }
    }
}