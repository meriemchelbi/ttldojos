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
                new Card{Adjective = "canine", Animal = "jackall", Color = "brown"},
                new Card{Adjective = "yellow", Animal = "dog", Color = "brown"},
                new Card{Adjective = "canine", Animal = "wolf", Color = "black"},
                new Card{Adjective = "canine", Animal = "dog", Color = "yellow"},
                new Card{Adjective = "feline", Animal = "cat", Color = "brown"},
                new Card{Adjective = "feline", Animal = "lynx", Color = "yellow"},
                new Card{Adjective = "feline", Animal = "lion", Color = "yellow"},
                new Card{Adjective = "feline", Animal = "tiger", Color = "white"},
                new Card{Adjective = "feline", Animal = "cat", Color = "black"},
            };
        }
    }
}