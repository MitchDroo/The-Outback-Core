using System;

namespace Outback.App
{
    public class ConsoleDialogueView : IDialogueView
    {
        private readonly IOutbackLogger _logger = new OutbackLogger();

        public void Show()
        {
            _logger.LogDebug("Showing Dialogue Ui");
        }

        public void Hide()
        {
            _logger.LogDebug("Hiding Dialogue Ui");
        }

        public void DisplayLine(DialogueLine dialogueLine)
        {
            Console.WriteLine($"[{dialogueLine.Speaker.SpeakerName}]: \"{dialogueLine.Line}\"");
        }
    }
}