using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands
{
    public class Poker
    {
        public enum Suit
        {
            Spades, Diamonds, Hearts, Clubs
        }

        public enum Rank
        {
            Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
        }

        public class Card
        {
            public Suit Suit { get; set; }
            public Rank Rank { get; set; }

            public Card(Suit suit, Rank rank)
            {
                Suit = suit;
                Rank = rank;
            }
        }

        public class Deck
        {
            private List<Card> _cards = new List<Card>();
            private int _index = 0;
            private Random _random = new Random();

            public Deck()
            {
                for (var i = 0; i < 13; i++)
                {
                    _cards.Add(new Card(Suit.Spades, (Rank)i));
                    _cards.Add(new Card(Suit.Hearts, (Rank)i));
                    _cards.Add(new Card(Suit.Diamonds, (Rank)i));
                    _cards.Add(new Card(Suit.Clubs, (Rank)i));
                }
                Shuffle();
            }

            public Card Deal()
            {
                var card =  _cards[_index];
                _index++;
                return card;
            }

            public void Shuffle()
            {
                _index = 0;
                int n = _cards.Count;
                for (int i = 0; i < n; i++)
                {
                    int r = i + _random.Next(n - i);
                    var t = _cards[r];
                    _cards[r] = _cards[i];
                    _cards[i] = t;
                }
            }

        }
    }
}
