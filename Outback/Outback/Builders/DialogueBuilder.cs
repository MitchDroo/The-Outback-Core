namespace Outback
{
    public class DialogueBuilder : TestDataBuilder<Dialogue>
    {
        private DialogueLine[] _lines;
        private long _id;

        public DialogueBuilder WithId(long id)
        {
            _id = id;
            return this;
        }

        public DialogueBuilder WithLines(params DialogueLine[] lines)
        {
            _lines = lines;
            return this;
        }
        
        public override Dialogue Build()
        {
            return new Dialogue(_id, _lines);
        }
    }
}