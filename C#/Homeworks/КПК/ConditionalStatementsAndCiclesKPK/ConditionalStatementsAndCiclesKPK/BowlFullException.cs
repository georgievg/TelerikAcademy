using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalStatementsAndCiclesKPK
{
    public class BowlFullException : Exception
    {
        public BowlFullException(string message)
            : base(message)
        {

        }
    }
}
