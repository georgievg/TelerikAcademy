using System;


namespace LeastMajorityMultiple
{
    class Program
    {
        static void Main()
        {
            byte a = byte.Parse(Console.ReadLine()),
                 b = byte.Parse(Console.ReadLine()),
                 c = byte.Parse(Console.ReadLine()),
                 d = byte.Parse(Console.ReadLine()),
                 e = byte.Parse(Console.ReadLine());
            bool looping = true;
            int counter = 0;
            byte divicible = 0;
            while (divicible <3)
            {
                
                    divicible = 0;
                    counter++;
                    if (counter % a == 0)
                    {
                        divicible++;
                    }
                    if (counter % b == 0)
                    {
                        divicible++;
                    }
                    if (counter % c == 0)
                    {
                        divicible++;
                    }
                    if (counter % d == 0)
                    {
                        divicible++;
                    }
                    if (counter % e == 0)
                    {
                        divicible++;
                    }
                    
                
                
            }
            Console.WriteLine(counter);



        }
    }
}
