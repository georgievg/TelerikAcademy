using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poker
{
    public enum HandStrenght
    {
        HighCard = 1,
        OnePair = 2,
        TwoPair = 3,
        ThreeOfAKind = 4,
        Straight = 5,
        Flush = 6,
        FullHouse = 7,
        FourOfAKind = 8,
        StraightFlush = 9
    }
}