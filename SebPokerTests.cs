using System;
using System.Collections.Generic;
using Xunit;

namespace PokerHands
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var smile = "😀   😐  😠";
        }

        [Fact]
        public void CanInitializeDeck()
        {
            List<Poker.Card> handOne = new List<Poker.Card>();
            List<Poker.Card> handtwo = new List<Poker.Card>();

            var deck = new Poker.Deck();

            for (var i = 0;  i < 5; i++)
            {
                handOne.Add(deck.Deal());
                handtwo.Add(deck.Deal());
            }


            var evaluator = new HandEvaluator();

            var handOneScore = evaluator.Score(handOne);
            var handTwoScore = evaluator.Score(handtwo);
            
        }

        [Fact]
        public void CanRankRoyalFlush()
        {
            var hand = new List<Poker.Card>
            {
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Ace),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.King),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Queen),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Jack),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Ten),
            };

            var handEvaluator = new HandEvaluator();

            var result = handEvaluator.Score(hand);

            Assert.Equal(900, result);
        }

        [Fact]
        public void CanScoreStraightFlush()
        {
            var hand = new List<Poker.Card>
            {
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Eight),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Seven),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Six),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Five),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Four),
            };

            var handEvaluator = new HandEvaluator();
            var result = handEvaluator.Score(hand);

            Assert.Equal(800, result);
        }

        [Fact]
        public void CanScoreFourOfAKind()
        {
            var hand = new List<Poker.Card>
            {
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Jack),
                new Poker.Card(Poker.Suit.Diamonds, Poker.Rank.Jack),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Jack),
                new Poker.Card(Poker.Suit.Spades, Poker.Rank.Jack),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Four),
            };

            var handEvaluator = new HandEvaluator();
            var result = handEvaluator.Score(hand);

            Assert.Equal(700, result);
        }

        [Fact]
        public void CanScoreFullHouse()
        {
            var hand = new List<Poker.Card>
            {
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Jack),
                new Poker.Card(Poker.Suit.Diamonds, Poker.Rank.Jack),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Jack),
                new Poker.Card(Poker.Suit.Spades, Poker.Rank.Four),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Four),
            };

            var handEvaluator = new HandEvaluator();
            var result = handEvaluator.Score(hand);

            Assert.Equal(600, result);
        }

        [Fact]
        public void CanScoreFlush()
        {
            var hand = new List<Poker.Card>
            {
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Jack),
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Ten),
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Four),
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Three),
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Queen),
            };

            var handEvaluator = new HandEvaluator();
            var result = handEvaluator.Score(hand);

            Assert.Equal(500, result);
        }

        [Fact]
        public void CanScoreStraight()
        {
            var hand = new List<Poker.Card>
            {
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Nine),
                new Poker.Card(Poker.Suit.Diamonds, Poker.Rank.Eight),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Seven),
                new Poker.Card(Poker.Suit.Spades, Poker.Rank.Six),
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Five),
            };

            var handEvaluator = new HandEvaluator();
            var result = handEvaluator.Score(hand);

            Assert.Equal(400, result);
        }

        [Fact]
        public void CanScoreThreeOfAKind()
        {
            var hand = new List<Poker.Card>
            {
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Nine),
                new Poker.Card(Poker.Suit.Diamonds, Poker.Rank.Nine),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Nine),
                new Poker.Card(Poker.Suit.Spades, Poker.Rank.Six),
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Five),
            };

            var handEvaluator = new HandEvaluator();
            var result = handEvaluator.Score(hand);

            Assert.Equal(300, result);
        }

        [Fact]
        public void CanScoreTwoPair()
        {
            var hand = new List<Poker.Card>
            {
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Nine),
                new Poker.Card(Poker.Suit.Diamonds, Poker.Rank.Nine),
                new Poker.Card(Poker.Suit.Clubs, Poker.Rank.Six),
                new Poker.Card(Poker.Suit.Spades, Poker.Rank.Six),
                new Poker.Card(Poker.Suit.Hearts, Poker.Rank.Five),
            };

            var handEvaluator = new HandEvaluator();
            var result = handEvaluator.Score(hand);

            Assert.Equal(200, result);
        }
    }
}
