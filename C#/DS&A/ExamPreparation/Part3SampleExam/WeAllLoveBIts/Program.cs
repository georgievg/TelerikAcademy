using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace WeAllLoveBIts
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                int number = int.Parse(Console.ReadLine());
                int replaced = ReplaceP(number);
                int reversed = ReverseP(number);
                int result = (number ^ replaced) & reversed;
                sb.AppendLine(result.ToString());
            }

            Console.WriteLine(sb);
        }

        private static int ReplaceP(int P)
        {
            string binary = Convert.ToString(P, 2);
            StringBuilder sb = new StringBuilder();
            foreach (var bit in binary)
            {
                if (bit == '1')
                {
                    sb.Append('0');
                }
                else
                {
                    sb.Append('1');
                }
            }

            return Convert.ToInt32(sb.ToString(), 2);
        }

        private static int ReverseP(int P)
        {
            string binary = Convert.ToString(P, 2);
            char[] chars = binary.ToArray();
            var reversed = chars.Reverse().ToArray();
            string reversedStr = null;
            for (int i = 0; i < reversed.Length; i++)
            {
                reversedStr += reversed[i];
            }

            return Convert.ToInt32(reversedStr, 2);
        }
    }   

}
