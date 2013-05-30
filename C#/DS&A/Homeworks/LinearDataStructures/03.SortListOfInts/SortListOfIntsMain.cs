using System;
using System.Collections.Generic;
using System.Linq;
using _1.AverageAndSumOfNumbers;

namespace _03.SortListOfInts
{
    class SortListOfIntsMain
    {
        static void Main()
        {
            List<int> numbers = NumbersFromConsoleReader.ReadNumbers().ToList();
            var orderedNumbers = numbers.OrderBy(x => x);

            Console.WriteLine("Sorted numbers : {0}",string.Join(", ",orderedNumbers));
        }
    }
}
