using _1.AverageAndSumOfNumbers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ReadNumbersAndReversWithStack
{
    class Program
    {
        static void Main()
        {
            Stack<int> numbers = new Stack<int>();
            int[] numbersArr = NumbersFromConsoleReader.ReadNumbers();
            foreach (var num in numbersArr)
            {
                numbers.Push(num);
            }

            Console.WriteLine("Normal numbers order : {0}",string.Join(", ",numbers));
            Console.Write("Reversed : ");

            int numbersLength = numbers.Count;
            for (int i = 0; i < numbersLength; i++)
            {
                Console.Write("{0}, ",numbers.Pop());
            }

            Console.WriteLine();
        }
    }
}
