using System;
using System.Collections.Generic;
using System.Linq;
using GuessZoo.domain;

namespace GuessZoo.service
{
    public interface IManagementSvc
    {
        void Start();
        void AddQuestion(Descriptor desc, string ask);
        IEnumerable<Card> RemainingCards { get; }
        bool Guess(string colour, string animal, string adjective);
    }

    public class ManagementSvc : IManagementSvc
    {
        private readonly IListLoaderSvc _listLoaderSvc;
        private readonly IRandomCardPicker _randomCardPicker;
        private readonly ICardComparer _cardComparer;
        private IList<Func<Card, bool>> _filters = new List<Func<Card, bool>>();
        private Card _chosenOne;
        private IEnumerable<Card> _allCards;

        public ManagementSvc(IListLoaderSvc listLoaderSvc, IRandomCardPicker randomCardPicker, ICardComparer cardComparer)
        {
            _listLoaderSvc = listLoaderSvc;
            _randomCardPicker = randomCardPicker;
            _cardComparer = cardComparer;
        }

        public void Start()
        {
            _filters = new List<Func<Card, bool>>();
            _allCards = _listLoaderSvc.GetCards();
            _chosenOne = _randomCardPicker.PickRandomCard(_allCards);
        }

        public void AddQuestion(Descriptor desc, string ask)
        {
            _filters.Add(_cardComparer.GetSinglePropertyComparer(_chosenOne, desc, ask));
        }

        public bool Guess(string colour, string animal, string adjective)
        {
            bool success = _cardComparer.CompareGuess(colour, animal, adjective, _chosenOne);
            if (!success) Start();
            return success;
        }

        public IEnumerable<Card> RemainingCards => _allCards.Where(c => _filters.All(f => f(c)));
    }
}