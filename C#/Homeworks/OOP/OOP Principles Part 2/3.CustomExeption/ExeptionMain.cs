using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CustomExeption
{
    class ExeptionMain
    {
        static void Main()
        {
            Console.WriteLine("Enter a int");
            int someInt = int.Parse(Console.ReadLine());
            if (someInt > 100 || someInt < 1)
            {
                throw new InvalidRangeExeption<int>(1, 100, "You entered a value out of the range 1 - 100",new Exception());
            }
        }
    }
}
