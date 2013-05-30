using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.OccurancesOfNumbers
{
    internal struct OccuringNumber
    {
        public int Value { get; set; }
        public int Count { get; set; }

        public OccuringNumber(int value, int count)
            : this()
        {
            this.Value = value;
            this.Count = count;
        }
    }
}
