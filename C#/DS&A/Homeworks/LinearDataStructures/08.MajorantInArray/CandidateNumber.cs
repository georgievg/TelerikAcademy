using System;

namespace _08.MajorantInArray
{
    struct CandidateNumber
    {
        public int Value { get; set; }
        public int Count { get; set; }

        public CandidateNumber(int value, int count)
            :this()
        {
            this.Value = value;
            this.Count = count;
        }
    }
}
