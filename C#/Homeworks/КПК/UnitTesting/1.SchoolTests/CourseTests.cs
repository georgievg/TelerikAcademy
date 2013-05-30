using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace _1.SchoolTests
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateCourseWithNoName()
        {
            School school = new School();
            school.AddCourse("");   
        }
        [TestMethod]
        public void CreateCourseWithName()
        {
            School school = new School();
            school.AddCourse("test");
            var expected = 1;
            var actual = school.Courses.Count;
            Assert.AreEqual(expected, actual);  
        }

        [TestMethod]
        public void CreateCourseWithNameAndCheckit()
        {
            School school = new School();
            school.AddCourse("test");
            var expected = "test";
            var actual = school.Courses.Find(x => x.CourseName == "test").CourseName;
            Assert.AreEqual(expected, actual);  
        }

        
    }
}
