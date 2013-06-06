using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.CountValuesInArray
{
    class CountValuesMain
    {
        static void Main()
        {
            var arr = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Dictionary<double, int> numbers = new Dictionary<double, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int count = 1;
                if (numbers.ContainsKey(arr[i]))
                {
                    count = numbers[arr[i]] + 1;
                }
                numbers[arr[i]] = count;
            }

            foreach (var val in numbers)
            {
                Console.WriteLine("{0} -> {1} times",val.Key,val.Value);
            }
        }
    }
}
