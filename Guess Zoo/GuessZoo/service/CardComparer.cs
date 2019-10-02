using GuessZoo.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessZoo.service
{  
    class CardComparer
    {
        private readonly ListFilter _listFilter;
        Dictionary<string, List<string>> dimensionAttributes;

        public CardComparer()
        {
            _listFilter = new ListFilter();    
        }

        // Full card comparison. All 3 properties must match for a positive.
        public bool CompareCards(Card selectedCard, Card guessedCard)
        {
            return string.Equals(selectedCard.Adjective, guessedCard.Adjective) &&
                   string.Equals(selectedCard.Animal,    guessedCard.Animal) &&
                   string.Equals(selectedCard.Color,     guessedCard.Color);

            //if (!string.Equals(selectedCard.Adjective, guessedCard.Adjective))
            //    return false;
            //if (!string.Equals(selectedCard.Animal, guessedCard.Animal))
            //    return false;
            //if (!string.Equals(selectedCard.Color, guessedCard.Color))
            //    return false;

            //return true;
        }

        // Returns dict of match outcome against possible dimensions on selected card.
        public Dictionary<string, bool> CompareCriterion(string criterion, Card selected, List<Card> cards)
        {
            Dictionary<string, bool> results = new Dictionary<string, bool> { };

            var dimensions = MapCriterion(criterion, cards);
            foreach (var dimension in dimensions)
            {
                bool match = CompareDimension(dimension, criterion, selected);
                results.Add(dimension, match);
            }

            return results;
        }

        // returns list of dimensions which contain our criterion as a possible value
        private List<string> MapCriterion(string criterion, List<Card> cards)
        {
            List<string> matchedDimensions = new List<string> { };
            dimensionAttributes = _listFilter.ListDimensionAttributes(cards);

            foreach (var dimensionAttribute in dimensionAttributes)
            {
                var dimension = dimensionAttribute.Key;
                var attribute = dimensionAttribute.Value;

                if (attribute.Contains(criterion))
                {
                    matchedDimensions.Add(dimension);
                }
            }

            return matchedDimensions;
        }

        // Matches my guess against the relevant 'dimensions' on selected card
        private bool CompareDimension(string dimension, string criterion, Card selected)
        {
            bool result;
            string selectedAttribute = "";

            switch (dimension)
            {
                case var d when dimension == "Animal":
                    selectedAttribute = selected.Animal;
                    break;

                case var d when dimension == "Adjective":
                    selectedAttribute = selected.Adjective;
                    break;

                case var d when dimension == "Color":
                    selectedAttribute = selected.Color;
                    break;

            }

            if (string.Equals(selectedAttribute, criterion))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;

        }

        
    }
}
