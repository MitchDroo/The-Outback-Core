using System.Collections.Generic;

namespace Outback
{
    public interface IDialogueSpeakerRepository
    {
        DialogueSpeaker GetBySpeakerName(string speakerName);
        List<DialogueSpeaker> GetAll();
        void Add(DialogueSpeaker dialogueSpeaker);
        void Remove(DialogueSpeaker dialogueSpeaker);
        void Update(DialogueSpeaker dialogueSpeaker);
    }
}