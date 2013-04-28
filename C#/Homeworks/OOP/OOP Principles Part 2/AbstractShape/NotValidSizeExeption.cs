using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShape
{
    class NotValidSizeExeption : ApplicationException
    {
        public NotValidSizeExeption(string msg)
            : base(msg)
        {
            
        }
        public NotValidSizeExeption(string msg, Exception ex)
            : base(msg, ex)
        {
        }
    }
}
