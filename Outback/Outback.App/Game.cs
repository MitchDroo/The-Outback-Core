namespace Outback.App
{
    public class Game
    {
        private readonly DialogueRunner _dialogueRunner;
        private readonly IDialogueRepository _dialogueRepository;
        private readonly IDialogueSpeakerRepository _dialogueSpeakerRepository;

        public Game(DialogueRunner dialogueRunner)
        {
            _dialogueRunner = dialogueRunner;
            _dialogueSpeakerRepository = new DialogueSpeakerRepository();
            _dialogueRepository = new DialogueRepository();
        }

        public void Run()
        {
            Bootstrap();
            _dialogueRunner.StartDialogue(_dialogueRepository.FindById(1));
            _dialogueRunner.AdvanceDialogue();
            _dialogueRunner.AdvanceDialogue();
            _dialogueRunner.AdvanceDialogue();
            _dialogueRunner.AdvanceDialogue();
        }

        private void Bootstrap()
        {
            _dialogueSpeakerRepository.Add(A.DialogueSpeaker().WithName("Laventon"));
            _dialogueRepository.Add(A.Dialogue().WithId(1).WithLines(
                    A.DialogueLine().WithSpeaker(_dialogueSpeakerRepository.GetBySpeakerName("Laventon")).WithLine("*Sigh* Alas... Yet another miss!"),
                    A.DialogueLine().WithSpeaker(_dialogueSpeakerRepository.GetBySpeakerName("Laventon")).WithLine("Aha! I'm glad you've come to my rescue, my new friend from the sky!"),
                    A.DialogueLine().WithSpeaker(_dialogueSpeakerRepository.GetBySpeakerName("Laventon")).WithLine("I've tried catching my little runaways by tossing some Poke Balls their way, but I'm not the best at this sort of thing, you see..."),
                    A.DialogueLine().WithSpeaker(_dialogueSpeakerRepository.GetBySpeakerName("Laventon")).WithLine("I'd love to give you a go at it, but perhaps I should tell you a bit about these three first?"),
                    A.DialogueLine().WithSpeaker(_dialogueSpeakerRepository.GetBySpeakerName("Laventon")).WithLine("Now, that one is Rowlet!")
            ));
        }
    }
}