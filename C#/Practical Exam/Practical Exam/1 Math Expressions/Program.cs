using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telerik_Software_Academy_2011__2012
{
    class Program
    {
        static void Main(string[] args)
        {
            double  n =     double.Parse(Console.ReadLine()),
                    m =     double.Parse(Console.ReadLine()),
                    p =     double.Parse(Console.ReadLine());

           
            
            double numerator = (n * n + (1.0 / (m * p)) + 1337.0);
            double denominator = (n - (128.523123123 * p));
            double expression;            
            expression = ((numerator / denominator) + Math.Sin((int)m % 180));
            Console.WriteLine("{0:F6}", expression);
            
            

        }
    }
}
