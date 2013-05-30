using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2___Abstract_Human
{
    class Program
    {
        static Random rnd = new Random();
        static void Main()
        {
            List<Human> humans = new List<Human>();
            List<Student> students = new List<Student>();
            students.Add(new Student("Pesho", "Peshev", rnd.Next(1, 11)));
            students.Add(new Student("Georgi", "Georgiev", rnd.Next(1, 11)));
            students.Add(new Student("Svetlin", "Angelov", rnd.Next(1, 11)));
            students.Add(new Student("Mariq", "Tomova", rnd.Next(1, 11)));
            students.Add(new Student("Stefan", "Stoqnov", rnd.Next(1, 11)));
            students.Add(new Student("Irena", "Zumbuluva", rnd.Next(1, 11)));
            students.Add(new Student("Margarita", "Geogieva", rnd.Next(1, 11)));
            students.Add(new Student("Dimitur", "Genchev", rnd.Next(1, 11)));
            students.Add(new Student("Ilqn", "Dimitrov", rnd.Next(1, 11)));
            students.Add(new Student("Galq", "Ivanova", rnd.Next(1, 11)));
            var sortedStudents = students.OrderBy(x => x.Grade).Select(x => x);
            foreach (var stud in sortedStudents)
            {
                Console.WriteLine("{0} with grade : {1}",stud.Name,stud.Grade);
                humans.Add(stud);
            }
            Console.WriteLine();
            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Ivan", "Georgiev",      500,16));
            workers.Add(new Worker("Tom", "Ivanov",      1000,23));
            workers.Add(new Worker("Geno", "Dimitrov",      299,23));
            workers.Add(new Worker("Mariq", "Stoqnova",     999,13));
            workers.Add(new Worker("Aneliq", "Yordanova",244,23));
            workers.Add(new Worker("Jar", "Computers",       439,12));
            workers.Add(new Worker("Cappy", "Pulpy",        3143,8));
            workers.Add(new Worker("Ognqn", "Ognqnov",      132,5));
            workers.Add(new Worker("Petar", "Borisov", 431, 4));
            workers.Add(new Worker("Todor", "Tomov",       341,2));
            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour()).Select(x => x);
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine("{0} receives {1} per hour",worker.Name,worker.MoneyPerHour());
                humans.Add(worker);
            }
            Console.WriteLine();
            var sortedHumans = humans.OrderBy(x => x.Name).ThenBy(x => x.LastName).Select(x => x);
            foreach (var human in sortedHumans)
            {
                Console.WriteLine("{0} {1}",human.Name,human.LastName);
            }
        }
    }
}
