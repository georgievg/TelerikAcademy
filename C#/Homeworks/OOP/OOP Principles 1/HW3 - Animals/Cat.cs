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
    public class Cat:Animals
    {
        protected Cat()
        {

        }

        public Cat(string name, string sex, int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
        public override string ProduceSound()
        {
            return string.Format("{0} is Meowing", this.Name);
        }
        public string Sleep()
        {
            return string.Format("{0} is sleeping", this.Name);
        }
        public string Eat()
        {
            return string.Format("{0} is hunting birds", this.Name);
        }
    }
}