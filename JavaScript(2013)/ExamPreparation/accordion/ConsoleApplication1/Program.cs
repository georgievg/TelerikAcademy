using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 1; // резултат от числата
            int number = 7;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}
