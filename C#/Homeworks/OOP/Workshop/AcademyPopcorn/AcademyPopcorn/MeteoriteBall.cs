using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft,speed)
        {
        }
    }
}