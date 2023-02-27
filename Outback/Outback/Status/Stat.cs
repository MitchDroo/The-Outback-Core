namespace Outback.Status
{
    public class Stat
    {
        private int _value;

        public Stat(string name, int value, int max)
        {
            Name = name;
            _value = value;
            Max = max;
        }

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                if (_value < 0)
                {
                    _value = 0;
                }
                else if (_value > Max)
                {
                    _value = Max;
                }
            }
        }

        public int Max { get; set; }
        public string Name { get; set; }

        public void Fill() => Value = Max;
        public void Empty() => _value = 0;
        public void IncreaseBy(float percent) => Max = (int)(Max * percent);
        public void DecreaseBy(float percent) => Max = (int)(Max * percent);
    }
}