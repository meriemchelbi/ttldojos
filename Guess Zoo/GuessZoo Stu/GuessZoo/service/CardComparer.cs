using System;
using GuessZoo.domain;

namespace GuessZoo.service
{
    public interface ICardComparer
    {
        Func<Card, bool> GetSinglePropertyComparer(Card chosenOne, Descriptor descriptor, string guess);
        bool CompareGuess(string colour, string animal, string adjective, Card chosenOne);
    }

    public class CardComparer : ICardComparer
    {
        private readonly ICardDescriptorComparisonRepository _comparisonRepository;

        public CardComparer(ICardDescriptorComparisonRepository comparisonRepository)
        {
            _comparisonRepository = comparisonRepository;
        }

        public bool CompareGuess(string colour, string animal, string adjective, Card chosenOne)
        {
            return chosenOne.Color == colour && chosenOne.Animal == animal && chosenOne.Adjective == adjective;
        }

        public Func<Card, bool> GetSinglePropertyComparer(Card chosenOne, Descriptor descriptor, string guess)
        {
            Func<Card, string, bool> comparison = _comparisonRepository.GetCardComparison(descriptor);

            return comparison(chosenOne, guess)
                ? (Func<Card, bool>) (card => comparison(card, guess))
                : card => !comparison(card, guess);
        }
    }
}