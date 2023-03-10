namespace Outback
{
    public static class A
    {
        public static DialogueBuilder Dialogue() => new DialogueBuilder();
        public static DialogueLineBuilder DialogueLine() => new DialogueLineBuilder();
        public static DialogueSpeakerBuilder DialogueSpeaker() => new DialogueSpeakerBuilder();
    }
}