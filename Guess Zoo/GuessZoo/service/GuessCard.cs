using GuessZoo.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessZoo.service
{
    public class GuessCard
    {
        public bool Result { get; set; }
        
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



    }
}
