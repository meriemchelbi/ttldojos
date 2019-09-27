using System;
using System.Collections.Generic;
using GuessZoo.domain;

namespace GuessZoo.service
{
    public class ManagementSvc
    {
        private readonly ListLoaderSvc _listLoaderSvc;
        private readonly GuessCard _guessCard;
        private readonly CardComparer _cardComparer;

        public ManagementSvc()
        {
            _listLoaderSvc = new ListLoaderSvc();
            _guessCard = new GuessCard();
            _cardComparer = new CardComparer();
        }

        public void Run()
        {
            Console.WriteLine("GuessZoo?");
            List<Card> allCards = _listLoaderSvc.GetCards();
            Card selected = PickRandomCard(allCards);
            string action = AskOrGuess();
            if (action == "ask")
            {
                Console.WriteLine("This bit hasn't been implemented yet.");
            }
            else if (action == "guess")
            {
                Guess(selected);
            }

        }

        public Card PickRandomCard(List<Card> cards)
        {
            Random r = new Random();
            var randInt = r.Next(0, cards.Count);
            return cards[randInt];
        }

        public string AskOrGuess()
        {
            Console.WriteLine("Would you like to 'ask' a question, or 'guess' a card?");
            string action = Console.ReadLine();

            return action;
                     
        }

        public void Guess(Card selectedCard)
        {
            Card guessCard = _guessCard.CaptureGuess();
            var result = _cardComparer.CompareCards(selectedCard, guessCard);
            _guessCard.Result = result;
            _guessCard.DisplayGuessOutcome(guessCard, selectedCard);

        }

        
    }
}