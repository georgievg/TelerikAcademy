using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace homework_1
{
    //
    [AttributeUsage(AttributeTargets.All,AllowMultiple=true)]
    public class Version2Attribute : System.Attribute
    {
        public string version { get; private set; }

        public Version2Attribute(string version)
        {
            this.version = version;
        }
    }
}