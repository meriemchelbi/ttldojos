using System;
using System.Collections.Generic;
using GuessZoo.domain;

namespace GuessZoo.service
{
    public class ManagementSvc
    {
        private readonly ListLoaderSvc _listLoaderSvc;

        public ManagementSvc()
        {
            _listLoaderSvc = new ListLoaderSvc();
        }

        public void Run()
        {
            Console.WriteLine("GuessZoo?");
            List<Card> allCards = _listLoaderSvc.GetCards();
            Card selected = PickRandomCard(allCards);
        }

        public Card PickRandomCard(List<Card> cards)
        {
            Random r = new Random();
            var randInt = r.Next(0, cards.Count);
            return cards[randInt];
        }
    }
}