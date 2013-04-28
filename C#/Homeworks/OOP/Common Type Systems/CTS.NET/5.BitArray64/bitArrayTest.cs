using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.BitArray64
{
    class bitArrayTest
    {
        static void Main(string[] args)
        {
            BitArray64 ba = new BitArray64(50);
            BitArray64 ba2 = new BitArray64(50);
            for (int i = 0; i < ba.Length; i++)
            {
                ba[i] = (ulong)i;
                ba2[i] = (ulong)i;
            }
            Console.WriteLine(ba.Equals(ba2));
            Console.WriteLine(ba == ba2);
            Console.WriteLine(ba != ba2);
        }

    }
}
