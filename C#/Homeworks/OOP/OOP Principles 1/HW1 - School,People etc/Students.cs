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
    public class Students : People
    {
        private int classNumber;

        private int ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            set
            {
                this.classNumber = value;
            }
        }
        public Students(string name,int classNumber,string comment=null)
        {
            this.Name = name;
            this.ClassNumber = classNumber;
            this.Comment = comment;
        }
    }
}