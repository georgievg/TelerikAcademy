using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyPopcorn
{
    public class UnpassableBlock : Block
    {
        public const char Symbol = '/';
        public new const string CollisionGroupString = "unpassableBlock";

        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol;
        }
        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball";
        }
    }
}