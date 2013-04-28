using System;

namespace UnitTesting
{
    public class _1School
    {
        static void Main()
        {
            School newSchool = new School();
            newSchool.AddCourse("test");
            var foundCourse = newSchool.Courses.Find(x => x.CourseName == "test");
            foundCourse.AddStudent("Gaco", newSchool);
        }
    }
}
