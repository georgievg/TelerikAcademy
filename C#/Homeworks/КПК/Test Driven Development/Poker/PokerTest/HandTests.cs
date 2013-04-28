using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;
namespace PokerTests
{
    [TestClass]
    public class HandTests
    {

        [TestMethod]
        public void ToStringHand()
        {
            List<Card> cards = new List<Card>(){
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards.ToArray());

            var excpected = "10♥Q♦K♣7♠9♣";
            var actual = hand.ToString();
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void ToStringHandCaseTwo()
        {
            List<Card> cards = new List<Card>(){
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards.ToArray());

            var excpected = "A♥Q♦8♣J♠9♣";
            var actual = hand.ToString();
            Assert.AreEqual(excpected, actual);
        }
    }
}
