using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MajorantInArray
{
    class MajorantMain
    {
        static void Main()
        {
            int[] arr = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            List<CandidateNumber> possibleNumbers = FindPossibleMajorands(arr);
            CandidateNumber majorand = possibleNumbers.FirstOrDefault(x => x.Count > arr.Length / 2);

            if (majorand.Value != 0 && majorand.Count != 0)
            {
                Console.WriteLine("The majorand in the array [{0}] is -> {1} appearing -> {2} times", string.Join(", ", arr), majorand.Value, majorand.Count);
            }
            else
            {
                Console.WriteLine("The array [{0}] has no majorand", string.Join(", ", arr));
            }
        }

        private static List<CandidateNumber> FindPossibleMajorands(int[] arr)
        {
            int[] sortedArr = arr.OrderBy(x => x).ToArray();
            List<CandidateNumber> candidates = new List<CandidateNumber>();
            int candidate = int.MinValue;
            int count = 1;

            for (int i = 0; i < sortedArr.Length; i++)
            {
                int currNum = sortedArr[i];
                if (currNum != candidate)
                {
                    if (candidate != int.MinValue)
                    {
                        candidates.Add(new CandidateNumber(candidate, count));
                    }

                    candidate = currNum;
                    count = 1;
                }
                else
                {
                    count++;
                }
            }

            candidates.Add(new CandidateNumber(candidate, count));
            return candidates;
        }
    }
}
