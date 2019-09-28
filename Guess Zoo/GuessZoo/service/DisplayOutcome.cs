using GuessZoo.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessZoo.service
{
    class DisplayOutcome
    {

        public void DisplayGuessOutcome(Card guessedCard, Card selectedCard, bool result)
        {
            string outcome;

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

        public void DisplayAskOutcome(Card lastCard)
        {
            Console.WriteLine($"You guessed it! The animal is a {lastCard.Color}, {lastCard.Adjective}, {lastCard.Animal}.");
        }
    }
}
