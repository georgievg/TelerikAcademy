using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.AverageAndSumOfNumbers
{
    class AverageAndSumOfNumbersMain
    {
        static void Main()
        {
            List<int> numbers = new List<int>();
            numbers = NumbersFromConsoleReader.ReadNumbers().ToList();            

            if (numbers.Count > 0)
            {
                Console.WriteLine("Numbers : {0}", string.Join(", ", numbers));
                Console.WriteLine("Average : {0} , Sum : {1}", numbers.Average(), numbers.Sum());
            }
            else
            {
                Console.WriteLine("No numbers");
            }
        }
    }
}