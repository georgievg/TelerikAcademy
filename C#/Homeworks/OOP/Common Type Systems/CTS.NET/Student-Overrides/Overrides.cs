using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_Overrides
{
    class Overrides
    {
        static void Main()
        {
            Student stud = new Student("Gosho", "Georgiev", "peshev", 431, "re3ef", 341, "431qe", 34, Specialty.Hlebar, University.EG, Faculties.ThisWOuldMean);
            Student stud2 = new Student("Gosho", "Georgiev", "peshev", 431, "re3ef", 341, "431qe", 34, Specialty.Hlebar, University.EG, Faculties.ThisWOuldMean);
            Console.WriteLine(stud != stud2);
            if (stud.CompareTo(stud2) > 1)
            {
                Console.WriteLine("stud is after stud2");
            }
            else if (stud.CompareTo(stud2) < 1)
            {
                Console.WriteLine("stud is before stud2");
            }
            else
            {
                Console.WriteLine("stud and stud2 are equal");
            }
        }
    }
}
