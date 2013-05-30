using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalStatementsAndCiclesKPK
{
    public abstract class Vegetable
    {
        public bool HasBeenPeeled { get; set; }
        public bool IsRotten { get; set; }

        public Vegetable()
        {
            this.HasBeenPeeled = false;
        }
    }
}
