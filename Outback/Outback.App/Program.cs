namespace Outback.App
{
    public class Program
    {
        public static void Main()
        {
            var dialogueView = new ConsoleDialogueView();
            var dialogueRunner = new DialogueRunner(dialogueView);
            var game = new Game(dialogueRunner);
            game.Run();
        }
    }
}