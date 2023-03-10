using System;

namespace Outback
{
    [Serializable]
    public struct DialogueSpeaker
    {
        public string SpeakerName;

        public DialogueSpeaker(string speakerName)
        {
            SpeakerName = speakerName;
        }
    }
}