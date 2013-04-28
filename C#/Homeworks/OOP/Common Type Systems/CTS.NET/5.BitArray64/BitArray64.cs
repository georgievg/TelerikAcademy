using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5.BitArray64
{
    public class BitArray64 : IEnumerable<int>
    {
        private int count;
        private ulong[] arr;
        public int Length
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }
        public BitArray64(int count)
        {
            this.Length = count;
            arr = new ulong[this.Length];
        }
        public ulong this[int index]
        {
            get
            {
                if (index > this.Length || index < 0)
                {
                    throw new IndexOutOfRangeException("Index was outside the bonds of the array");
                }
                return this.arr[index];
            }
            set
            {
                if (value > ulong.MaxValue)
                {
                    throw new OverflowException("You have exceeded the maximum value of 9223372036854775808");
                }
                else if (value < ulong.MinValue)
                {
                    throw new OverflowException("You have exceeded the minimum value of 0");
                }
                this.arr[index] = value;
            }
        }
        public override bool Equals(object obj)
        {
            BitArray64 ba = obj as BitArray64;
            if (ba == null)
            {
                return false;
            }
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] != ba[i])
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            ulong halfSum = 0;
            ulong otherHalfSum = 0;
            for (int i = 0; i < this.Length/2; i++)
            {
                halfSum += this[i];
            }
            for (int i = this.Length/2; i < this.Length; i++)
            {
                otherHalfSum += this[i];
            }
            return halfSum.GetHashCode() ^ otherHalfSum.GetHashCode();
        }
        public static bool operator ==(BitArray64 ba1, BitArray64 ba2)
        {
            return BitArray64.Equals(ba1, ba2);
        }
        public static bool operator !=(BitArray64 ba1, BitArray64 ba2)
        {
            return !(BitArray64.Equals(ba1, ba2));
        }
        public IEnumerator<int> GetEnumerator()
        {
            BitArray64 ba = this;
            int index = 0;
            var currentEl = ba[index];
            while (index < this.Length)
            {
                yield return (int)currentEl;
                if (index == this.Length-1)
                {
                    break;
                }
                index++;
                currentEl = ba[index];


            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}