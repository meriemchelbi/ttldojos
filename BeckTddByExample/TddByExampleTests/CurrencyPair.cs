using System;
using System.Collections.Generic;
using System.Text;

namespace TddByExampleTests
{
    public class CurrencyPair
    {
        private readonly string fromCurrency;
        private readonly string toCurrency;

        public CurrencyPair(string fromCurrency, string toCurrency)
        {
            this.fromCurrency = fromCurrency;
            this.toCurrency = toCurrency;
        }

        public override bool Equals(Object obj)
        {
            var pair = (CurrencyPair)obj;
            return fromCurrency.Equals(pair.fromCurrency) && toCurrency.Equals(pair.toCurrency);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
