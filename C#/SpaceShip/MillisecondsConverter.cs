using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceShip
{
    public static class MillisecondsConverter
    {
        public static int ConvertSecondsToMinutes(int milliseconds)
        {
            return (int)(TimeSpan.FromMilliseconds(milliseconds).TotalSeconds);
        }
    }
}