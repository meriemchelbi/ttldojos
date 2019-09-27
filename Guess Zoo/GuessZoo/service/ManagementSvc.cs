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
            var guessCard = new GuessCard();

            Console.WriteLine("Would you like to ask a question, or guess a card?");
            string answer = Console.ReadLine();

            if (answer == "ask")
            {
                Console.WriteLine("This bit isn't ready yet!");
            }
            else if (answer == "guess")
            {
                guessCard.SingleGuess(selectedCard);
            }
        }
    }
}