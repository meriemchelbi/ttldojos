using GuessZoo.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessZoo.service
{
    public class GuessCard
    {
        public bool Result { get; set; }
        string outcome;
        
        public Card CaptureGuess()
        {
            var guessedCard = new Card();

            Console.WriteLine("Guess the adjective?");
            guessedCard.Adjective = Console.ReadLine();

            Console.WriteLine("Guess the color?");
            guessedCard.Color = Console.ReadLine();

            Console.WriteLine("Guess the animal?");
            guessedCard.Animal = Console.ReadLine();

            return guessedCard;
        }

        public void DisplayGuessOutcome(Card guessedCard, Card selectedCard)
        {
            if (Result == true)
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
