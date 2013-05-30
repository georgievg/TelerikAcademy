using System;
using System.Collections.Generic;

namespace UnitTesting
{
    public class Course
    {
        private const int MAX_STUDENTS = 30;
        private string courseName;


        public List<Student> Students { get; set; }
        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            private set
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentNullException("Name of course can not be null");
                }
                this.courseName = value;
            }
        }

        public Course(string courseName)
        {
            this.Students = new List<Student>();
            this.CourseName = courseName;
        }


        public void AddStudent(string name,School school)
        {
            if (this.Students.Count > 30)
            {
                throw new OverflowException("Maximum number of students in this course has been reached - 30");
            }
            this.Students.Add(new Student(name, school));
        }
                
    }
}
