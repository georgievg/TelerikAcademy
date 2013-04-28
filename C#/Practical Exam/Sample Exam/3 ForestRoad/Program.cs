using System;


class Program
{
    static int width, i;
    static void Main()
    {
        width = int.Parse(Console.ReadLine());
        int height = 2*width-1;       
        int counter = width;

        for (i = 0; i <= height/2; i++)
        {
            for (int s = 0; s < width; s++)
            {
                if (s != i)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }

        for (int g = height/2-1; g >= 0; g--)
        {
            for (int s = 0; s < width; s++)
            {
                if (s != g)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            
        }
        
        




        

    }
    
}
