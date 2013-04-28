using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace _1.SchoolTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AddNewStudent()
        {
            School school = new School();
            school.AddCourse("test");
            var course = school.Courses.Find(x => x.CourseName == "test");
            course.AddStudent("Gosho", school);
            var expected = "Gosho";
            var foundCourse =  school.Courses.Find(x => x.CourseName == "test");
            var foundStuden = foundCourse.Students.Find(x => x.Name == "Gosho");
            var actual = foundStuden.Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Add31NewStudents()
        {
            School school = new School();
            school.AddCourse("test");
            var course = school.Courses.Find(x => x.CourseName == "test");
            for (int i = 0; i <= 31; i++)
            {
                course.AddStudent("Gosho", school);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewEmptyStudent()
        {
            School school = new School();
            school.AddCourse("newTest");
            var course = school.Courses.Find(x => x.CourseName == "newTest");
            course.AddStudent("", school);
            var expected = "Gosho";
            var foundCourse = school.Courses.Find(x => x.CourseName == "test");
            var foundStuden = foundCourse.Students.Find(x => x.Name == "Gosho");
            var actual = foundStuden.Name;
            Assert.AreEqual(expected, actual);
        }


    }
}
