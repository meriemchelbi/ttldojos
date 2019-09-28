using GuessZoo.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessZoo.service
{
    class DisplayText
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

        public void DisplayAskOutcome(List<Card> allCards)
        {
            Console.WriteLine($"\nThe animal is a {allCards[0].Color}, {allCards[0].Adjective}, {allCards[0].Animal}. \n" );
            
        }

        internal void DisplayAllCards(List<Card> allCards)
        {
            Console.WriteLine("\nHere are the remaining animals... \n");
            foreach (var card in allCards)
            {
                Console.WriteLine($"{card.Color} {card.Adjective} {card.Animal}");
            }
        }
    }
}
