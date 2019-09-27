using GuessZoo.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessZoo.service
{  
    class CardComparer
    {

        public bool Result;

        // method compare on a guess
        // input card (to compare), descriptionType, Property string
        // output bool
        // calls out to functions repo- dict of descriptions mapped to comparer functions

        public bool CompareCards(Card selectedCard, Card guessedCard)
        {
            Console.WriteLine("You've reached the end of the flow!");

            // if AdjCompare True
            // AND if ColCompar True
            // AND if AnimalCompare True
            // Result = true
            // else Result = false

            return Result;
        }
    }
}
