using System;
using System.Numerics;





class Program
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine()),
            y = double.Parse(Console.ReadLine());
        double output = 0;

        if (x == 0 && y == 0)
        {
            output = 0;
        }
        if (x == 0)
        {
            if (y > 0 || y < 0)
            {
                output = 5;
            }
        }
        if(x >= 1)
        {
            if (y == 0)
            {
                output = 6;
            }
            else if(y >= 1)
            {
                output = 1;
            }
            else if (y <= -1)
            {
                output = 4;
            }

        }
        else if (x <= -1)
        {
            if (y == 0)
            {
                output = 6;
            }
            else if (y <= 1)
            {
                output = 3;
            }
            else if (y >= 1)
            {
                output = 2;
            }
        }
        Console.WriteLine(output);

    }
}

