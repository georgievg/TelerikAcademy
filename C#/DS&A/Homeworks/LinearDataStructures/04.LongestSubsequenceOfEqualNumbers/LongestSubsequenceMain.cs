using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.LongestSubsequenceOfEqualNumbers
{
    public class LongestSubsequenceMain
    {
        static void Main()
        {
            List<int> numbers = new List<int>() { 1, 1, 1, 5, 6, 7, 7, 7, 7, 8, 9, 1, 1, 0, 1, 1 };
            List<int> result = FindLongestSubsequenceOfEqualNumbers(numbers);

            Console.WriteLine("The Longest Subsequence of Equal Numbers is the number {0} - {1} times",
                result[0], result.Count);
        }

        //There are more optimal solutions but i had to return a list and i couldn't think of anything
        //faster than O(n)
        public static List<int> FindLongestSubsequenceOfEqualNumbers(List<int> sequence)
        {
            sequence.Sort();
            int candidate = 0;
            int count = 1;
            int best = 0;
            int bestCount = 1;

            for (int i = 0; i < sequence.Count; i++)
            {
                int currNum = sequence[i];
                if (currNum != candidate)
                {
                    if (count > bestCount)
                    {
                        bestCount = count;
                        best = candidate;
                    }

                    candidate = currNum;
                    count = 1;
                }
                else
                {
                    count++;
                }
            }

            List<int> result = new List<int>();
            for (int i = 0; i < bestCount; i++)
            {
                result.Add(best);
            }

            return result;
        }
    }
}