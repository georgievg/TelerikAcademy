using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace HW1___School_People_etc
{
    //
    public class School
    {
        private List<ClassesOfStudents> classes;

        public List<ClassesOfStudents> Classes
        {
            get
            {
                return this.classes;
            }
            set
            {
                this.classes = value;
            }
        }

    }
}