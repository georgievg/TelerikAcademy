using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;
using System.Collections.Generic;

namespace _1.SchoolTests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void BlankSchoolCreation()
        {
            School school = new School();
            var expected = 0;
            var actual = school.Courses.Count;
            Assert.AreEqual(expected, actual);
        }

        

    }
}
