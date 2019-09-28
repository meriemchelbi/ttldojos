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
        private readonly AskQuestion _askQuestion;
        private readonly ListFilter _listFilter;
        private readonly DisplayText _displayText;
        Dictionary<string, bool> results;
        List<Card> allCards;


        public ManagementSvc()
        {
            _listLoaderSvc = new ListLoaderSvc();
            _guessCard = new GuessCard();
            _cardComparer = new CardComparer();
            _askQuestion = new AskQuestion();
            _listFilter = new ListFilter();
            _displayText = new DisplayText();
            allCards = _listLoaderSvc.GetCards();
        }

        public void Run()
        {
            Console.WriteLine("GuessZoo? \n");
            _displayText.DisplayAllCards(allCards);
            Card selected = PickRandomCard(allCards);
            string action = AskOrGuess();
           if (action == "ask")
            {
                Ask(selected);
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
            Console.WriteLine("\nWould you like to 'ask' a question, or 'guess' a card? \n");
            string action = Console.ReadLine();

            return action;
                     
        }

        public void Guess(Card selectedCard)
        {
            Card guessCard = _guessCard.CaptureGuess();
            var guessResult = _cardComparer.CompareCards(selectedCard, guessCard);
            _displayText.DisplayGuessOutcome(guessCard, selectedCard, guessResult);
        }



        public void Ask(Card selected)
        {
            while (allCards.Count > 1)
            {
                _displayText.DisplayAllCards(allCards);
                string criterion = _askQuestion.CaptureCriteria();
                results = _cardComparer.CompareCriterion(criterion, selected, allCards);
                _listFilter.FilterList(allCards, criterion, selected, results);
            }
            if (allCards.Count == 1)
            {
                _displayText.DisplayAskOutcome(allCards);
            }
            
        }

    }
}