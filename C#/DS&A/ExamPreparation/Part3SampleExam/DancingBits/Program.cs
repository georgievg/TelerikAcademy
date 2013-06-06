using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DancingBits
{
    class Program
    {
        static void Main()
        {
            int K = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                int number = int.Parse(Console.ReadLine());
                string toBinary = Convert.ToString(number,2);
                sb.Append(toBinary);
            }

            string bits = sb.ToString();
            string newBits = "2" + bits;
            Stack<string> bitsStack = new Stack<string>();
            foreach (var ch in newBits)
            {
                bitsStack.Push(ch.ToString());
            }

            int counter = 1; 
            int dancingBits = 0;
            while(bitsStack.Count > 1)
            {
                string currentNumber = bitsStack.Pop();
                string previousNumber = bitsStack.Peek();
                if (currentNumber == previousNumber)
                {
                    counter++;
                }
                else if (currentNumber != previousNumber)
                {
                    if (counter == K)
                    {
                        dancingBits++;
                    }

                    counter = 1;
                }
            }

            Console.WriteLine(dancingBits);
        }
    }
}
