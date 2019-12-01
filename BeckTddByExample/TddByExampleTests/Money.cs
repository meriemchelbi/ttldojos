using System;
using System.Collections.Generic;
using System.Text;

namespace TddByExampleTests
{
    public class Money: IExpression
    {
        public Money(int amount, string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }
        
        internal int amount;
        internal string currency;


        internal static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        internal static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }
        
        public override bool Equals(Object moneyObject)
        {
            Money money = (Money)moneyObject;
            return amount == money.amount
                && GetCurrency().Equals(money.GetCurrency());
        }

        internal Money Times(int multiplier)
        {
            return new Money(amount * multiplier, currency);
        }

        internal IExpression Plus(Money addend)
        {
            return new Sum(addend, this);
        }

        internal string GetCurrency()
        {
            return currency;
        }

        public Money Reduce(Bank bank, string toCurrency)
        {
            int rate = bank.GetRate(currency, toCurrency);
            return new Money(amount / rate, toCurrency);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
