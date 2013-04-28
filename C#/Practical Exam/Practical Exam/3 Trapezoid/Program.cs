using System;

/*Write a program that prints on the console the border of a trapezoid by given number N.
The width of the top side of the trapezoid must be exactly N.
The width of the bottom side of the trapezoid must be exactly 2 * N.
The height of the trapezoid must be exactly N + 1.
Also the top right and the bottom right angle of the trapezoid must be equal to 90 degrees.
See the examples bellow.
.....*****
....*....*
...*.....*
..*......*
.*.......*
**********
*/

namespace Trapezoid
{
    class Program
    {
        static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());
            #region LoopForTheTopSide
            for (int i = 0; i < n*2+1; i++)
            {
                if (i < n)
                {
                    Console.Write(".");
                }
                if (i > n && i < (n * 2) - 1)
                {
                    Console.Write("*");
                }
                if (i == n * 2)
                {
                    Console.Write("*");
                    Console.WriteLine("*");
                    break;
                }
            }
            #endregion
            #region LoopForTheMiddleSide
            byte charCounter = 1;
            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < n*2+1; j++)
                {
                    if (j < n - charCounter)
                    {
                        Console.Write(".");
                    }
                    if (j == n - charCounter)
                    {
                        Console.Write("*");
                    }
                    if (j > n - charCounter && j < n * 2-1)
                    {
                        Console.Write(".");
                    }
                    if (j == n * 2)
                    {
                        Console.WriteLine("*");
                    }
                    
                }
                charCounter++;
            }

            #endregion
            #region LoopForTheBottomSide
            for (int i = 0; i < n*2; i++)
            {
                Console.Write("*");
            }
            #endregion




        }
    }
}
