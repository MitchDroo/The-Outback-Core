using System;

namespace Outback
{
    [Serializable]
    public struct Dialogue
    {
        public long Id;
        public DialogueLine[] Lines;

        public Dialogue(long id, DialogueLine[] lines)
        {
            Id = id;
            Lines = lines;
        }

        public int TotalLines => Lines.Length;

        public DialogueLine GetLine(int index)
        {
            return Lines[index];
        }
    }
}