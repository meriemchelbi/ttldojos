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
        private readonly DisplayOutcome _displayOutcome;
        bool result;
        List<Card> allCards;


        public ManagementSvc()
        {
            _listLoaderSvc = new ListLoaderSvc();
            _guessCard = new GuessCard();
            _cardComparer = new CardComparer();
            _askQuestion = new AskQuestion();
            _listFilter = new ListFilter();
            _displayOutcome = new DisplayOutcome();
        }

        public void Run()
        {
            Console.WriteLine("GuessZoo?");
            List<Card> allCards = _listLoaderSvc.GetCards();
            Card selected = PickRandomCard(allCards);
            string action = AskOrGuess();
            if (action == "ask")
            {
                Console.WriteLine("Not implemented");
                //Ask(selected);
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
            var guessResult = _cardComparer.CompareCards(selectedCard, guessCard);
            _guessCard.Result = guessResult;
            _displayOutcome.DisplayGuessOutcome(guessCard, selectedCard, guessResult);
        }



        public void Ask(Card selected)
        {
            var resultList = _listFilter.RemainingCards;
            
            while (resultList.Count > 1)
            {   
                List<string> criteria = _askQuestion.CaptureCriteria();
                foreach (var criterion in criteria)
                {
                    result = _cardComparer.CompareCriterion(criterion);
                    _listFilter.FilterList(allCards, criteria, result);
                }
                _listFilter.DisplayRemainingCards();
            }
            if (resultList.Count == 1)
            {
                Card lastCard = resultList[0];
                _displayOutcome.DisplayAskOutcome(lastCard);
            }
        }

    }
}