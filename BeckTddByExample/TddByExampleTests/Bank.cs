using System;
using System.Collections;

namespace TddByExampleTests
{
    public class Bank
    {
        public Bank()
        {
        }

        private Hashtable rates = new Hashtable();

        public Money Reduce(IExpression source, string toCurrency)
        {
            return source.Reduce(this, toCurrency);
        }

        internal void AddRate(string fromCurrency, string toCurrency, int exchangeRate)
        {
            rates.Add(new CurrencyPair(fromCurrency, toCurrency), exchangeRate);
        }

        internal int GetRate(string fromCurrency, string toCurrency)
        {
            if (fromCurrency.Equals(toCurrency)) return 1;
            var rate = (int)rates[new CurrencyPair(fromCurrency, toCurrency)];
            return rate;

        }
    }
}