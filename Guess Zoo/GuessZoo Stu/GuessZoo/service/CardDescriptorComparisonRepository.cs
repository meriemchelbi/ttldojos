using System;
using GuessZoo.domain;
using System.Collections.Generic;

namespace GuessZoo.service
{
    public interface ICardDescriptorComparisonRepository
    {
        Func<Card, string, bool> GetCardComparison(Descriptor desc);
    }

    public class CardDescriptorComparisonRepository : ICardDescriptorComparisonRepository
    {
        private readonly IDictionary<Descriptor, Func<Card, string, bool>> _lookup;

        public CardDescriptorComparisonRepository()
        {
            _lookup = new Dictionary<Descriptor, Func<Card, string, bool>>
            {
                {Descriptor.Adjective, (c, a)=>c.Adjective.Equals(a, StringComparison.CurrentCultureIgnoreCase) },
                {Descriptor.Colour, (c, a)=>c.Color.Equals(a, StringComparison.CurrentCultureIgnoreCase) },
                {Descriptor.Animal, (c, a)=>c.Animal.Equals(a, StringComparison.CurrentCultureIgnoreCase) },
            };
        }

        public Func<Card, string, bool> GetCardComparison(Descriptor desc)
        {
            if (_lookup.ContainsKey(desc))
                return _lookup[desc];
            return (c, a) => false;
        }
    }

    public enum Descriptor
    {
        Colour,
        Animal,
        Adjective
    }
}