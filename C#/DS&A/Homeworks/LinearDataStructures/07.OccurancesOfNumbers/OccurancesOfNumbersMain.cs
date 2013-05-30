using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.OccurancesOfNumbers
{
    class OccurancesOfNumbersMain
    {
        static void Main()
        {
            List<int> numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            List<OccuringNumber> occuringNumbers = GetNumbersOccurances(numbers);

            foreach (var num in occuringNumbers)
            {
                Console.WriteLine("The number {0} occurs {1} times",num.Value,num.Count);
            }
        }

        private static List<OccuringNumber> GetNumbersOccurances(List<int> numbers)
        {
            List<OccuringNumber> result = new List<OccuringNumber>();
            numbers.Sort();

            int candidate = int.MinValue;
            int count = 1;
            for (int i = 0; i < numbers.Count; i++)
            {
                int currNumber = numbers[i];
                if (currNumber != candidate)
                {
                    if (candidate != int.MinValue)
                    {
                        result.Add(new OccuringNumber(candidate,count));
                    }

                    candidate = currNumber;
                    count = 1;
                }
                else 
                {
                    count++;
                    bool isAtTheEnd = i == numbers.Count - 1;
                    if (candidate != int.MinValue && isAtTheEnd)
                    {
                        result.Add(new OccuringNumber(candidate, count));
                    }
                }
            }

            return result;
        }
    }
}
