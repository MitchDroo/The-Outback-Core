using System.Collections.Generic;

namespace Outback.Combat
{
    public interface ICombatOptionSelectorView
    {
        void Show();
        void Hide();
        List<ICombatOption> Options { set; }
        ICombatOption Selected { get; }
        void Warn(string text);
    }
}