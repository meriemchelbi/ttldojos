using System;
using System.Collections.Generic;
using System.Text;

namespace TddByExampleTests
{
    public interface IExpression
    {
        Money Reduce(Bank bank, string toCurrency);
    }
}
