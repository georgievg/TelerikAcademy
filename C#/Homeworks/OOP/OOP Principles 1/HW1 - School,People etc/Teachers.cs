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
    public class Teachers : People
    {
        private List<Disciplines> disciplines;

        private List<Disciplines> Disciplines
        {
            get
            {
                return this.disciplines;
            }
            set
            {
                this.disciplines = value;
            }
        }
        public Teachers(string name, List<Disciplines> disciplines, string comment = null)
        {
            this.Name = name;
            this.Disciplines = disciplines;
            this.Comment = comment;
        }
    }
}