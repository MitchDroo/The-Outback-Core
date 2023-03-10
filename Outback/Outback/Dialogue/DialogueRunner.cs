namespace Outback
{
    public class DialogueRunner
    {
        private readonly IDialogueView _view;
        private Dialogue _dialogue;
        private int _currentIndex;

        public DialogueRunner(IDialogueView view)
        {
            _view = view;
        }

        public IDialogueView View => _view;

        public void StartDialogue(Dialogue dialogue)
        {
            _dialogue = dialogue;
            _currentIndex = 0;
            _view.Show();
            _view.DisplayLine(_dialogue.GetLine(_currentIndex));
        }

        public void AdvanceDialogue()
        {
            if (AtEndOfDialogue())
            {
                _view.Hide();
            }
            else
            {
                _view.DisplayLine(_dialogue.GetLine(++_currentIndex));
            }
        }

        private bool AtEndOfDialogue()
        {
            return _currentIndex >= _dialogue.TotalLines - 1;
        }
    }
}