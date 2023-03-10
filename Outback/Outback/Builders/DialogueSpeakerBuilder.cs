namespace Outback
{
    public class DialogueSpeakerBuilder : TestDataBuilder<DialogueSpeaker>
    {
        private string _speakerName;

        public DialogueSpeakerBuilder WithName(string speakerName)
        {
            _speakerName = speakerName;
            return this;
        }

        public override DialogueSpeaker Build()
        {
            return new DialogueSpeaker(_speakerName);
        }
    }
}