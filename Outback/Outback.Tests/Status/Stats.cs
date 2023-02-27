using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Outback.Status;

namespace Outback.Tests.Status
{
    public class Stats : IEnumerable<Stat>
    {
        private List<Stat> _stats;

        public Stats()
        {
            _stats = new List<Stat>();
        }

        public void Add(Stat stat) => _stats.Add(stat);
        public void Add(string name, int value) => _stats.Add(new Stat(name, value, value));
        public void Add(string name, int value, int max) => _stats.Add(new Stat(name, value, max));

        public IEnumerator<Stat> GetEnumerator() => _stats.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Stat this[string name]
        {
            get => Find(name);
            set
            {
                var found = Find(name);
                if (found == null) 
                    return;
                found.Value = value.Value;
                found.Max = value.Max;
            }
        }

        Stat Find(string name) =>_stats.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public void Fill()
        {
            foreach (var stat in _stats)
            {
                stat.Fill();
            }
        }
    }
}