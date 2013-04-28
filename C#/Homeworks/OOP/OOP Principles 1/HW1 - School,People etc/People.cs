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
    public class People
    {
        private string name;
        private string comment;

        protected string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new InvalidDataException("Name too short");
                }
                this.name = value;
            }
        }
        protected string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }
    }
}