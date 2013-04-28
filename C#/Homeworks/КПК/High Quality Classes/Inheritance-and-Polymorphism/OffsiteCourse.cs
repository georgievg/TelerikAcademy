using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        public string Town { get; private set; }

        public OffsiteCourse(string name):base(name,null,null)
        {
            this.Town = null;
        }
        
        public OffsiteCourse(string courseName, string teacherName):base(courseName,teacherName,new List<string>())
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students):base(courseName,teacherName,students)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town):base(courseName,teacherName,students)
        {
            this.Town = town;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string fromParent = base.ToString();
            sb.Append(fromParent);
            if (this.Town != null)
            {
                sb.Append("; Town = ");
                sb.Append(this.Town);
            }
            sb.Append(" }");

            return sb.ToString();

        }
    }
}
