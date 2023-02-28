using System.Collections.Generic;

namespace Outback.Combat
{
    public class CombatOptionSelector
    {
        private readonly ICombatOptionSelectorView _view;
        private List<ICombatOption> _options;

        public CombatOptionSelector(ICombatOptionSelectorView view, List<ICombatOption> options)
        {
            _view = view;
            _options = options;
        }

        public void Open()
        {
            _view.Options = _options;
            _view.Show();
        }

        public void Close()
        {
            _view.Hide();
        }

        public void SelectOption()
        {
            if (_view.Selected == null)
            {
                _view.Warn("No combat option selected!");
                return;
            }
            _view.Selected.Execute();
            Close();
        }
    }
}