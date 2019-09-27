using GuessZoo.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessZoo.service
{
    class GuessCard
    {
        bool result;
        String outcome;

        Card guessedCard = new Card();


        private void CaptureGuess()
        {
            Console.WriteLine("Guess the adjective?");
            guessedCard.Adjective = Console.ReadLine();

            Console.WriteLine("Guess the color?");
            guessedCard.Color = Console.ReadLine();

            Console.WriteLine("Guess the animal?");
            guessedCard.Animal = Console.ReadLine();

        }

        public void SingleGuess(Card selectedCard)
        {
            CaptureGuess();
            var cardCompare = new CardComparer();
            result = cardCompare.CompareCards(selectedCard, guessedCard);

            if(result == true)
            {
                outcome = "win";
            }
            else
            {
                outcome = "lose";
            }

            DisplayGuessOutcome(selectedCard);
        }

        private void DisplayGuessOutcome(Card selectedCard)
        {
            Console.WriteLine($"You guessed: {guessedCard.Adjective}, {guessedCard.Animal}, {guessedCard.Color}.");
            Console.WriteLine($"We selected: {selectedCard.Adjective}, {selectedCard.Animal}, {selectedCard.Color}.");
            Console.WriteLine($"You {outcome}!");
        }


    }
}
