using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.RemoveAllNegativeNumbersFromSequence
{
    public class RemoveNegativeNumbersMain
    {
        static void Main()
        {
            List<int> numbers = new List<int>() { 1, 4, 6, -5, -3, -1, 6, -5 };
            List<int> noNegatives = RemoveAllNegativeNumbers(numbers);

            Console.WriteLine("Result : {0}",string.Join(", ",noNegatives));
        }

        private static List<int> RemoveAllNegativeNumbers(List<int> numbers)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= 0)
                {
                    result.Add(numbers[i]);
                }
            }

            return result;
        }
    }
}
