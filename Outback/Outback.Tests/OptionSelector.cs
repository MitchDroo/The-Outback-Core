using System.Collections.Generic;

namespace Outback.Tests
{
    public class OptionSelector<T>
    {
        private readonly List<T> _options;
        private T _selected;

        private int _selectedIndex;
    
        public OptionSelector(List<T> options)
        {
            _options = options;
            _selectedIndex = 0;
            _selected = _options[_selectedIndex];
        }

        public void SelectNextEntry()
        {
            if (_selectedIndex >= _options.Count - 1) return;
            _selected = _options[++_selectedIndex];
        }

        public void SelectPreviousEntry()
        {
            if (_selectedIndex <= 0) return;
            _selected = _options[--_selectedIndex];
        }
    
        public List<T> Options => _options;
        public T Selected => _selected;
        public int TotalOptions => _options.Count;
    }
}