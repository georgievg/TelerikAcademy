using System;
using System.Collections.Generic;

namespace _10.ShortestSequenceOfOperations
{
    class ShortestSequenceMain
    {
        static void Main()
        {
            int n = 5;
            int m = 16;
            int current = m;
            Stack<int> numbers = new Stack<int>();
            numbers.Push(current);
            while (current / 2 >= n)
            {
                if (current % 2 == 0)
                {
                    current /= 2;
                    numbers.Push(current);
                }
                else
                {
                    current -= 1;
                    numbers.Push(current);
                    current /= 2;
                    numbers.Push(current);
                }
            }

            while (current - 2 >= n)
            {
                current -= 2;
                numbers.Push(current);
            }

            while (current - 1 >= n)
            {
                current -= 1;
                numbers.Push(current);
            }

            while (numbers.Count > 0)
            {
                Console.Write("{0} ,", numbers.Pop());
            }

        }
    }
}
