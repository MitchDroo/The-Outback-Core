using System;

namespace Outback
{
    [Serializable]
    public struct DialogueLine
    {
        public DialogueLine(DialogueSpeaker speaker, string line)
        {
            Speaker = speaker;
            Line = line;
        }
        
        public DialogueSpeaker Speaker;
        public string Line;
    }
}