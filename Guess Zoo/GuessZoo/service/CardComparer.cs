﻿using GuessZoo.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessZoo.service
{  
    class CardComparer
    {

        public bool Result;

        public bool CompareCards(Card selectedCard, Card guessedCard)
        {

            if(string.Equals(selectedCard.Adjective, guessedCard.Adjective))
            {
                if(string.Equals(selectedCard.Animal, guessedCard.Animal))
                {
                    if(string.Equals(selectedCard.Color, guessedCard.Color))
                    {
                        Result = true;
                    }
                }
                                
            }
            else
            {
                Result = false;
            }

            return Result;
        }

        public bool CompareCriterion(string criterion)
        {
            return true;
        }
    }
}
