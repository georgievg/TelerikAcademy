using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.AverageAndSumOfNumbers
{
    public static class NumbersFromConsoleReader
    {
        public static int[] ReadNumbers()
        {
            List<int> numbers = new List<int>();
            bool isNum;
            int result;
            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                isNum = int.TryParse(line, out result);
                if (isNum)
                {
                    numbers.Add(result);
                }

                line = Console.ReadLine();
            }

            return numbers.ToArray();
        }
    }
}
