using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void ToStringTwoClubs()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            var excpected = "2♣";
            var actual = card.ToString();
            Assert.AreEqual(excpected, actual);
        }
    }
}
