using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3___Animals
{
    public interface ISound
    {
        string ProduceSound();
    }
    class Program 
    {
        static void Main()
        {
            Animals[] animals = new Animals[5];
            animals[0] = new Cat("Jony", "Male", 4);
            animals[1] = new Tomcat("Pesho", 6);
            animals[2] = new Kitten("Maq", 7);
            animals[3] = new Dog("Afo", "Female", 9);
            animals[4] = new Frog("Froggy", "Male", 4);
            var averageAge = animals.Average(x => x.Age);
            Console.WriteLine("The average age is {0}",averageAge);
           
        }
    }
}
