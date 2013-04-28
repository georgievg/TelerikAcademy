using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1___School_People_etc
{
    class Program
    {
        static void Main()
        {
            School newSchool = new School();
            Students newSTud = new Students("Pesho", 55);
            Disciplines newDisc = new Disciplines("Istoriq",55,55);
            List<Disciplines> disciplines = new List<Disciplines>();
            disciplines.Add(newDisc);
            Teachers newTeacher = new Teachers("Maq",disciplines);
            List<Teachers> teachers = new List<Teachers>();
            teachers.Add(newTeacher);
            List<Students> studends = new List<Students>();
            studends.Add(newSTud);
            ClassesOfStudents newClass = new ClassesOfStudents("Pesho",studends,teachers);
            newSchool.Classes.Add(newClass);
        }
    }
}
