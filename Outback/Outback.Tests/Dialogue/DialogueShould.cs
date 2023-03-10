using FluentAssertions;
using NUnit.Framework;

namespace Outback.Tests
{
    [TestFixture]
    public class DialogueShould
    {
        private Dialogue _dialogue;

        [SetUp]
        public void Setup()
        {
            var speaker = A.DialogueSpeaker().WithName("Test");
            var line = A.DialogueLine().WithSpeaker(speaker).WithLine("Test");
            _dialogue = A.Dialogue()
                .WithId(1)
                .WithLines(line);
        }
        
        [Test]
        public void Get_Total_Lines()
        {
            _dialogue.TotalLines.Should().Be(1);
        }

        [Test]
        public void Get_Line()
        {
            var dialogueLine = _dialogue.GetLine(0);

            dialogueLine.Should().Be(_dialogue.Lines[0]);
        }
    }
}