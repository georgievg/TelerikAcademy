using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.RemoveAllOddOccuringNumbers
{
    class RemoveOddOccuring
    {
        static void Main()
        {
            List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            List<int> noOddOccuring = RemoveOddOccuringNumbers(numbers);

            Console.WriteLine("Result : {0}", string.Join(", ", noOddOccuring));
        }

        private static List<int> RemoveOddOccuringNumbers(List<int> numbers)
        {
            numbers.Sort();
            List<int> newNumbers = new List<int>();
            int candidate = 0;
            int count = 1;

            for (int i = 0; i < numbers.Count; i++)
            {
                int currNum = numbers[i];
                if (currNum != candidate)
                {
                    bool countIsEven = count % 2 == 0;
                    if (countIsEven)
                    {
                        AddValidNumbers(count, candidate, newNumbers);
                    }

                    candidate = currNum;
                    count = 1;
                }
                else
                {
                    count++;
                    bool isAtTheEnd = i == numbers.Count - 1;
                    bool countIsEven = count % 2 == 0;
                    if (isAtTheEnd && countIsEven)
                    {
                        AddValidNumbers(count, candidate, newNumbers);
                    }
                }
            }

            return newNumbers;
        }
  
        private static void AddValidNumbers(int count, int candidate, List<int> newNumbers)
        {
            for (int j = 0; j < count; j++)
            {
                newNumbers.Add(candidate);
            }
        }
    }
}