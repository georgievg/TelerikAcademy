using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillars
{
    class Program
    {
        private static char[,] arr = new char[8, 8];
        private static int bitsAmount = 0;

        static void Main()
        {
            ReadInput();
            DoTheBlackMagick();
        }

        private static void DoTheBlackMagick()
        {
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                bool hasEqualBits = CheckForEqualBits(col);
                if (hasEqualBits)
                {
                    Console.WriteLine(7 - col);
                    Console.WriteLine(bitsAmount);
                    return;
                }                
            }

            Console.WriteLine("No");
        }

        private static bool CheckForEqualBits(int startCol)
        {
            int bitsLeft = 0;
            int bitsRight = 0;
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < startCol; col++)
                {
                    if (arr[row, col] == '1')
                    {
                        bitsLeft++;
                    }
                }
            }

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = startCol+1; col < arr.GetLength(1); col++)
                {
                    if (arr[row, col] == '1')
                    {
                        bitsRight++;
                    }
                }
            }
            bool bitsAreEqual = bitsLeft == bitsRight;
            if (bitsAreEqual)
            {
                bitsAmount = bitsLeft;
            }

            return bitsAreEqual;
        }

        private static void ReadInput()
        {
            for (int i = 0; i < 8; i++)
            {
                byte line = byte.Parse(Console.ReadLine());
                string toBinary = Convert.ToString(line, 2);
                string zeros = null;
                if (toBinary.Length < 8)
                {
                    zeros = new string('0', 8 - toBinary.Length);
                    zeros += toBinary;
                }
                else
                {
                    zeros = toBinary;
                }

                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    arr[i, j] = zeros[j];
                }
            }
        }
    }
}