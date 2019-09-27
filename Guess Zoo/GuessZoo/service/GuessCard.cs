using GuessZoo.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessZoo.service
{
    class GuessCard
    {
        bool result;
        string outcome;
        Card guessedCard;
        Card selectedCard;
        private readonly CardComparer _cardCompare;

        public GuessCard()
        {
            _cardCompare = new CardComparer();
        }

        public void SingleGuess(Card SelectedCard)
        {
            selectedCard = SelectedCard;
            CaptureGuess();
            result = _cardCompare.CompareCards(selectedCard, guessedCard);
            DisplayGuessOutcome();
        }

        private void CaptureGuess()
        {
            guessedCard = new Card();
            
            Console.WriteLine("Guess the adjective?");
            guessedCard.Adjective = Console.ReadLine();

            Console.WriteLine("Guess the color?");
            guessedCard.Color = Console.ReadLine();

            Console.WriteLine("Guess the animal?");
            guessedCard.Animal = Console.ReadLine();

        }

        private void DisplayGuessOutcome()
        {
            if (result == true)
            {
                outcome = "win";
            }
            else
            {
                outcome = "lose";
            }
            Console.WriteLine($"You guessed: {guessedCard.Adjective}, {guessedCard.Animal}, {guessedCard.Color}.");
            Console.WriteLine($"We selected: {selectedCard.Adjective}, {selectedCard.Animal}, {selectedCard.Color}.");
            Console.WriteLine($"You {outcome}!");
        }


    }
}
