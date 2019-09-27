using System;
using System.Collections.Generic;
using GuessZoo.domain;

namespace GuessZoo.service
{
    public class ManagementSvc
    {
        private readonly ListLoaderSvc _listLoaderSvc;
        private readonly GuessCard _guessCard;

        public ManagementSvc()
        {
            _listLoaderSvc = new ListLoaderSvc();
            _guessCard = new GuessCard();
        }

        public void Run()
        {
            Console.WriteLine("GuessZoo?");
            List<Card> allCards = _listLoaderSvc.GetCards();
            Card selected = PickRandomCard(allCards);
            AskOrGuess(selected);

        }

        public Card PickRandomCard(List<Card> cards)
        {
            Random r = new Random();
            var randInt = r.Next(0, cards.Count);
            return cards[randInt];
        }

        public void AskOrGuess(Card selectedCard)
        {
            Console.WriteLine("Would you like to ask a question, or guess a card? (enter 'guess' or 'ask')");
            string answer = Console.ReadLine();

            if (answer == "ask")
            {
                Console.WriteLine("This bit hasn't been implemented yet.");
            }
            else if (answer == "guess")
            {
                _guessCard.SingleGuess(selectedCard);
            }
        }
    }
}