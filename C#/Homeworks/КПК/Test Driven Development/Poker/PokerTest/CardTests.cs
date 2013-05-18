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

        [TestMethod]
        public void ToStringJackHearts()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Hearts);
            var excpected = "J♥";
            var actual = card.ToString();
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void ToStringTenDiamons()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            var excpected = "10♦";
            var actual = card.ToString();
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void ToStringAceSpades()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            var excpected = "A♠";
            var actual = card.ToString();
            Assert.AreEqual(excpected, actual);
        }
    }
}
