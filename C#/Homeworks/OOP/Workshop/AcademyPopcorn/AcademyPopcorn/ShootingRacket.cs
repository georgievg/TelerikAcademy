using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyPopcorn
{
    public class ShoothingRacket : Racket
    {
        private bool isShoot = false;

        public ShoothingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }
        public void Shoot()
        {
            isShoot = true;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (isShoot)
            {
                isShoot = false;
                produceObjects.Add(new Bullet(this.topLeft));
            }
            return produceObjects;
        }
    }
}