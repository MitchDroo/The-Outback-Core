namespace Outback
{
    public interface IDialogueView
    {
        void Show();
        void Hide();
        void DisplayLine(DialogueLine dialogueLine);
    }
}