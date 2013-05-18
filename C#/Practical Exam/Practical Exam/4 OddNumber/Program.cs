using System;
using System.Collections.Generic;
using System.Text;

namespace OddNumber
{
    class Program
    {
        static void Main()
        {

            // int n = int.Parse(Console.ReadLine());
            // long[] Numbers = new long[n];
            // for (int i = 0; i < n; i++)
            // {
            //     Numbers[i] = long.Parse(Console.ReadLine());
            //     
            // }
            // int oddCounter = 1;
            // long oddNumber = 0;
            // for (int i = 0; i < n; i++)
            // {
            //     for (int j = 0; j < n; j++)
            //     {
            //         if (j == i)
            //         {
            //             continue;
            //         }
            //         if (Numbers[i] == Numbers[j])
            //         {
            //             oddCounter++;
            //         }
            //     }
            //     if (oddCounter % 2 == 0)
            //     {
            //         oddCounter = 1;
            //         continue;
            //         
            //     }
            //     if (oddCounter % 2 != 0)
            //     {
            //         oddNumber = Numbers[i];
            //         break;
            //     }
            //     
            // }
            //
            //
            //
            // Console.WriteLine(oddNumber);



            string readStr = Console.ReadLine();
            int N = int.Parse(readStr);
            long currentNumber, result = 0;
            for (int i = 0; i < N; i++)
            {
                readStr = Console.ReadLine();
                currentNumber = long.Parse(readStr);
                result ^= currentNumber;
            }
            Console.WriteLine(result);


        }
    }
}
