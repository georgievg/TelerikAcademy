using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lines
{
    struct Line
    {
        public int Length { get; set; }

        public Line(int length) : this()
        {
            this.Length = length;
        }
    }

    class Program
    {
        static char[,] arr = new char[8, 8];
        static int maxLength = 0;
        static int linesWithMaxLength = 0;
        static List<Line> lines = new List<Line>();

        public static void Main()
        {
            ReadInput();
            ReadLines();
            
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Length == maxLength)
                {
                    linesWithMaxLength++;
                }
            }

            Console.WriteLine(maxLength);
            Console.WriteLine(linesWithMaxLength);
        }

        private static void ReadLines()
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                int counter = 0;
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    char curr = arr[row, col];
                    if (curr == '1')
                    {
                        counter++;
                        if (col == arr.GetLength(1) - 1)
                        {
                            if (counter > maxLength)
                            {
                                maxLength = counter;
                            }
                            lines.Add(new Line(counter));
                            counter = 0;
                        }
                    }
                    else if (curr == '0')
                    {
                        if (counter > maxLength)
                        {
                            maxLength = counter;
                        }
                        lines.Add(new Line(counter));
                        counter = 0;
                    }
                }
            }

            for (int col = 0; col < arr.GetLength(0); col++)
            {
                int counter = 0;
                for (int row = arr.GetLength(1) - 1; row >= 0; row--)
                {
                    char curr = arr[row, col];
                    if (curr == '1')
                    {
                        counter++;
                        if (row == 0)
                        {
                            if (counter > maxLength)
                            {
                                maxLength = counter;
                            }
                            lines.Add(new Line(counter));
                            counter = 0;
                        }
                    }
                    else if (curr == '0')
                    {
                        if (counter > maxLength)
                        {
                            maxLength = counter;
                        }
                        lines.Add(new Line(counter));
                        counter = 0;
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
    }
}