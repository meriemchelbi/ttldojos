using GuessZoo.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessZoo.service
{
    class ListFilter
    {

        // Apply appropriate filtering logic according to whether or not guess matches selected card.
        public void FilterList(List<Card> allCards, string criterion, Card selected, Dictionary<string, bool> results)
        {

            foreach (var result in results)
            {
                var dimension = result.Key;
                var match = result.Value;
                

                if (match == true)
                {
                    FilterOnPositiveMatch(criterion, dimension, allCards, selected);
                }
                else
                {
                    FilterOnNegativeMatch(criterion, dimension, allCards, selected);
                }
            }

        }

        // Filter out cards that match my (wrong) guess
        private void FilterOnNegativeMatch(string criterion, string dimension, List<Card> cards, Card selected)
        {

            for (int i = 0; i < cards.Count; )
           
            {
                string cardAttribute = "";

                switch (dimension)
                {
                    case var d when dimension == "Animal":
                        cardAttribute = cards[i].Animal;
                        break;

                    case var d when dimension == "Adjective":
                        cardAttribute = cards[i].Adjective;
                        break;

                    case var d when dimension == "Color":
                        cardAttribute = cards[i].Color;
                        break;

                }

                if (string.Equals(criterion, cardAttribute))
                {
                    cards.Remove(cards[i]);
                }
                else
                {
                    i++;
                }
            }
        }

        // Filter out cards that don't match my (correct) guess
        private void FilterOnPositiveMatch(string criterion, string dimension, List<Card> cards, Card selected)
        {
            for (int i = 0; i < cards.Count; )
            {
                string cardAttribute = "";

                switch (dimension)
                {
                    case var d when dimension == "Animal":
                        cardAttribute = cards[i].Animal;
                        break;

                    case var d when dimension == "Adjective":
                        cardAttribute = cards[i].Adjective;
                        break;

                    case var d when dimension == "Color":
                        cardAttribute = cards[i].Color;
                        break;

                }

                if (!string.Equals(criterion, cardAttribute))
                {
                    cards.Remove(cards[i]);
                }

                else
                {
                    i++;
                }
            }

        }


        // Work out possible attribute values for each type of card dimension/property
        public Dictionary<string, List<string>> ListDimensionAttributes(List<Card> cards)
        {
            var dimensionAttributes = new Dictionary<string, List<string>> {};

            List<string> ColorAttributes = new List<string> { };
            List<string> AnimalAttributes = new List<string> { };
            List<string> AdjectiveAttributes = new List<string> { };

            foreach (var card in cards)
            {
                ColorAttributes.Add(card.Color);
                AnimalAttributes.Add(card.Animal);
                AdjectiveAttributes.Add(card.Adjective);
            }

            // TODO: remove duplicate values

            dimensionAttributes.Add("Color", ColorAttributes);
            dimensionAttributes.Add("Animal", AnimalAttributes);
            dimensionAttributes.Add("Adjective", AdjectiveAttributes);

            return dimensionAttributes;

        }
    }
}
