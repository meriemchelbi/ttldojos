using System;
using System.Collections.Generic;
using System.Linq;
using GuessZoo.domain;

namespace GuessZoo.service
{
    public interface IRandomCardPicker
    {
        Card PickRandomCard(IEnumerable<Card> cards);
    }

    public class RandomCardPicker : IRandomCardPicker
    {
        public Card PickRandomCard(IEnumerable<Card> cards)
        {
            Random r = new Random();
            var randInt = r.Next(0, cards.Count());
            return cards.ToList()[randInt];
        }
    }
}