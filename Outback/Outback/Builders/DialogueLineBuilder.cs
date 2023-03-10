namespace Outback
{
    public class DialogueLineBuilder : TestDataBuilder<DialogueLine>
    {
        private DialogueSpeaker _speaker;
        private string _line;

        public DialogueLineBuilder WithSpeaker(DialogueSpeaker speaker)
        {
            _speaker = speaker;
            return this;
        }

        public DialogueLineBuilder WithLine(string line)
        {
            _line = line;
            return this;
        }

        public override DialogueLine Build()
        {
            return new DialogueLine(_speaker, _line);
        }
    }
}