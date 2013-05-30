using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace HW2___Abstract_Human
{
    //
    public class Student : Human
    {
        public int Grade { get; private set; }

        public Student(string name, string lastName,int grade)
        {
            this.Grade = grade;
            this.Name = name;
            this.LastName = lastName;
        }

    }

}