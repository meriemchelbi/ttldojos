using GuessZoo.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessZoo.service
{
    class GuessCard
    {
        public bool Result;

        public Card guessedCard = new Card();


        private void CaptureGuess()
        {
            Console.WriteLine("Guess the adjective?");
            guessedCard.Adjective = Console.ReadLine();

            Console.WriteLine("Guess the color?");
            guessedCard.Color = Console.ReadLine();

            Console.WriteLine("Guess the animal?");
            guessedCard.Animal = Console.ReadLine();

        }

        public bool SingleGuess(Card selectedCard)
        {
            CaptureGuess();
            var cardCompare = new CardComparer();
            Result = cardCompare.CompareCards(selectedCard, guessedCard);

            return Result;

        }


    }
}
