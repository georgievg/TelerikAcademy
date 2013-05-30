using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace HW3___Animals
{
    //
    public class Kitten:Cat
    {
        public Kitten(string name,int age)
        {
            this.Name = name;
            this.Sex = "female";
            this.Age = age;
        }
    }
}