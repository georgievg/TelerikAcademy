using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public string Lab { get; private set; }

        public LocalCourse(string name)
            : base(name, null, null)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName, new List<string>())
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }
       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string fromParent = base.ToString();
            sb.Append(fromParent);
            if (this.Lab != null)
            {
                sb.Append("; Lab = ");
                sb.Append(this.Lab);
            }
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
