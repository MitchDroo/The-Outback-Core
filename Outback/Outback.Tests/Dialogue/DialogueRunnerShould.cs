using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Outback.Tests
{
    [TestFixture]
    public class DialogueRunnerShould
    {
        private IDialogueView _view;
        private DialogueRunner _dialogueRunner;
        private Dialogue _dialogue;

        [SetUp]
        public void Setup()
        {
            _view = Substitute.For<IDialogueView>();
            _dialogueRunner = new DialogueRunner(_view);

            var speaker = A.DialogueSpeaker().WithName("Test Speaker");
            _dialogue = A.Dialogue().WithLines(
                A.DialogueLine().WithSpeaker(speaker).WithLine("Test"), 
                A.DialogueLine().WithSpeaker(speaker).WithLine("Another Line"), 
                A.DialogueLine().WithSpeaker(speaker).WithLine("Yet Another Line")
            );
        }

        [Test]
        public void Set_View()
        {
            _dialogueRunner.View.Should().Be(_view);
        }

        [Test]
        public void Show_Ui_When_Starting_Dialogue()
        {
            _dialogueRunner.StartDialogue(_dialogue);

            _view.Received().Show();
        }

        [Test]
        public void Display_First_Line_When_Dialogue_Started()
        {
            _dialogueRunner.StartDialogue(_dialogue);

            _view.Received().DisplayLine(_dialogue.Lines[0]);
        }

        [Test]
        public void Display_Next_Line_When_Previous_Line_Completed()
        {
            _dialogueRunner.StartDialogue(_dialogue);

            _dialogueRunner.AdvanceDialogue();
            
            _view.Received().DisplayLine(_dialogue.Lines[1]);
        }

        [Test]
        public void Display_Final_Line_When_All_Previous_Lines_Completed()
        {
            _dialogueRunner.StartDialogue(_dialogue);
            
            _dialogueRunner.AdvanceDialogue();
            _dialogueRunner.AdvanceDialogue();
            
            _view.Received().DisplayLine(_dialogue.Lines[2]);
        }
        
        [Test]
        public void Hide_Ui_When_All_Lines_Are_Completed()
        {
            _dialogueRunner.StartDialogue(_dialogue);

            _dialogueRunner.AdvanceDialogue();
            _dialogueRunner.AdvanceDialogue();
            _dialogueRunner.AdvanceDialogue();

            _view.Received().Hide();
        }
    }
}