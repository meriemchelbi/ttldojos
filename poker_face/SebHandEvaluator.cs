using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHands
{
    public class HandEvaluator
    {
        public int Score(IEnumerable<Poker.Card> hand)
        {
            if (hand.Any() == false)
                return 0;

            var handTotal = hand.Sum(card => (int)card.Rank); 
            var orderedHand = hand.OrderBy(card => card.Rank).ToList();

            if (IsRoyalFlush(orderedHand))
                return 900; 
            if (IsStraightFlush(orderedHand))
                return 800;
            if (IsFourOfAKind(orderedHand))
                return 700;
            if (IsFullHouse(orderedHand))
                return 600 ;
            if (IsFlush(orderedHand))
                return 500 ;
            if (IsStraight(orderedHand))
                return 400 ;
            if (IsThreeOfAKind(orderedHand))
                return 300 ;
            if (IsTwoPair(orderedHand))
                return 200 ;
            if (IsTwoOfAKind(orderedHand))
                return 100 ;

            return 0;
        }

        private bool IsRoyalFlush(List<Poker.Card> hand)
        {
            if (hand.Any(card => card.Rank < Poker.Rank.Ten))
                return false;

            var firstCard = hand.First();
            var lastCard = hand.Last();

            if (hand.Any(card => card.Suit != firstCard.Suit))
                return false;

            if (firstCard.Rank != Poker.Rank.Ten || lastCard.Rank != Poker.Rank.Ace)
                return false;

            return true;
        }

        private bool IsStraightFlush(List<Poker.Card> hand)
        {
            return IsStraight(hand) && IsFlush(hand);
        }

        private bool IsFourOfAKind(List<Poker.Card> hand)
        {
            return hand.GroupBy(card => card.Rank, card => card, (key, g) => new { Count = g.Count() }).Any(g => g.Count == 4);
        }

        private bool IsFullHouse(List<Poker.Card> hand)
        {
            var groupedByRank = hand.GroupBy(card => card.Rank, card => card, (key, g) => new { Rank = key, Count = g.Count() });

            return groupedByRank.Any(group => group.Count == 2) 
                   && groupedByRank.Any(group => group.Count == 3);
        }

        private bool IsFlush(List<Poker.Card> hand)
        {
            var first = hand.First();
            return hand.Any(card => card.Suit != first.Suit) == false;
        }

        private bool IsStraight(List<Poker.Card> hand)
        {
            var firstCard = hand.First();
            var lastCard = hand.Last();

            for (int i = 0; i < 4; i++)
            {
                var d = hand[i + 1].Rank - hand[i].Rank;
                if (d == 0)
                    return false;
                if (d > 1)
                {
                    if (hand[i + 1].Rank != Poker.Rank.Ace)
                        return false;
                }
            }

            if (hand.Last().Rank == Poker.Rank.Ace)
                return lastCard.Rank - firstCard.Rank == 12;

            return lastCard.Rank - firstCard.Rank == 4;
        }

        private bool IsThreeOfAKind(List<Poker.Card> hand)
        {
            return hand.GroupBy(card => card.Rank, card => card, (key, g) => new { Count = g.Count() }).Any(g => g.Count == 3);
        }

        private bool IsTwoPair(List<Poker.Card> hand)
        {
            var groups = hand.GroupBy(card => card.Rank, card => card, (key, g) => new { Count = g.Count() });
            return groups.Count() == 3;
        }

        private bool IsTwoOfAKind(List<Poker.Card> hand)
        {
            return hand.GroupBy(card => card.Rank, card => card, (key, g) => new { Count = g.Count() }).Any(g => g.Count == 2);
        }
    }
}
