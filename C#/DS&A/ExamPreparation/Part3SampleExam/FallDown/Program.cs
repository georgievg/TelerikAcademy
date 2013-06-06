using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FallDown
{
    class Program
    {
        private static char[,] arr = new char[8, 8];

        static void Main()
        {
            ReadInput();
            FallDown();
            string[] nS = GatherResults();

            for (int i = 0; i < nS.Length; i++)
            {
                Console.WriteLine(Convert.ToInt32(nS[i],2));
            }

        }

        private static string[] GatherResults()
        {
            string[] results = new string[8];
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    sb.Append(arr[row, col].ToString());
                }
                results[row] = sb.ToString();
                sb.Clear();
            }

            return results;
        }

        private static void FallDown()
        {
            for (int col = 0; col < arr.GetLength(0); col++)
            {
                for (int row = arr.GetLength(1) - 1; row >= 0; row--)
                {
                    char current = arr[row,col];
                    if (current == '1')
                    {
                        int newRow = row+1;
                        while (true)
                        {
                            if (newRow == arr.GetLength(1) || arr[newRow, col] == '1')
                            {
                                break;
                            }
                            else
                            {
                                arr[newRow-1, col] = '0';
                                arr[newRow, col] = '1';
                            }

                            newRow++;
                        }
                    }
                }
            }
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

        private static void PrintMatrix()
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write("{0} ", arr[row, col]);
                }
                Console.WriteLine("\r\n");
            }
        }
    }
}