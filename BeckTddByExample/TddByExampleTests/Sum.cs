using System;

namespace TddByExampleTests
{
    internal class Sum: IExpression
    {
        public Sum(Money augend, Money addend)
        {
            Augend = augend;
            Addend = addend;
        }
        public Money Augend { get; internal set; }

        public Money Addend { get; internal set; }

        public Money Reduce(Bank bank, string toCurrency)
        {
            var amount = Augend.amount + Addend.amount;
            return new Money(amount, toCurrency);
        }
    }
}