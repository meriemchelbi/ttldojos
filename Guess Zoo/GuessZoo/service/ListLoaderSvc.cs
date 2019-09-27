using System.Collections.Generic;
using GuessZoo.domain;

namespace GuessZoo.service
{
    public class ListLoaderSvc
    {
        public List<Card> GetCards()
        {
            return new List<Card>
            {
                new Card{Adjective = "feline", Animal = "cat", Color = "brown"}, 
                new Card{Adjective = "canine", Animal = "dog", Color = "brown"},
            };
        }
    }
}