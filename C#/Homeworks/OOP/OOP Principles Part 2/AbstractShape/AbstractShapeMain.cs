using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShape
{
    class AbstractShapeMain
    {
        static void Main()
        {
            double width = -5;
            double height = 7;
            Console.WriteLine("Circle's surface is {0}",new Circle(width).CalculateSurface());
            Console.WriteLine("Triangle's surface is {0}",new Triangle(width,height).CalculateSurface());
            Console.WriteLine("Rectangle's surface is {0}",new Rectangle(width,height).CalculateSurface());
        }
    }
}
