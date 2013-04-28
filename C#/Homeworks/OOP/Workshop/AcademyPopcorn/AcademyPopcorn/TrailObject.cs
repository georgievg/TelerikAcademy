using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        public int Lifetime { get; private set; }
        public TrailObject(MatrixCoords topLeft, int lifetime):base(topLeft,new char[,]{{'.'}})
        {
            this.Lifetime = lifetime;
        }

        public override void Update()
        {
            this.Lifetime--;
        }

    }
}