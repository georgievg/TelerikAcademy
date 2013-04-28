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
    public abstract class Animals : ISound
    {
        private string name;
        private int age;
        private string sex;
        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Name can not be null");
                }
                this.name = value;
            }
        }      
        public int Age
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if (value < 0 || value > 30)
                {
                    throw new Exception("This animal is probably not alive");
                }
                this.age = value;
            }
        }
        public string Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                if (value.ToLower() != "male" && value.ToLower() != "female")
                {
                    throw new Exception("Sex does not exist");
                }
                this.sex = value;
            }
        }
        public abstract string ProduceSound();
    }
}