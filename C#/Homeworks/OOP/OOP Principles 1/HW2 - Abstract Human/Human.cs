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
    public abstract class Human
    {
        private string name;
        private string lastName;

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
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            protected set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Last Name can no be null");
                }
                this.lastName = value;
            }
        }
    }
}