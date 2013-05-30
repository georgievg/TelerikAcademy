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
    public class Frog : Animals
    {
        public Frog(string name, string sex, int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
        public override string ProduceSound()
        {
            return string.Format("{0} is Kwaking", this.Name);
        }
        public string Jump()
        {
            return string.Format("{0} is jumping", this.Name);
        }
        public string Eat()
        {
            return string.Format("{0} is eating flies", this.Name);
        }

    }
}