using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalStatementsAndCiclesKPK
{
    class VegetableDoesNotExistsException : Exception
    {
        public VegetableDoesNotExistsException(string message)
            : base(message)
        {

        }
    }
}
