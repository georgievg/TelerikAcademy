using System;
using System.Collections.Generic;

namespace UnitTesting
{
    public class School
    {
        public List<Course> Courses { get; private set; }
        public List<int> Ids { get; private set; }

        public School()
        {
            this.Courses = new List<Course>();
        }

        public void AddCourse(string name)
        {
            this.Courses.Add(new Course(name));
        }

        public bool ContainsId(int id)
        {
            foreach (var course in this.Courses)
            {
                foreach (var student in course.Students)
                {
                    if (student.UniqueID == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
