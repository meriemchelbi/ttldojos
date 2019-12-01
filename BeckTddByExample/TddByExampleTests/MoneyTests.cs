using System;
using Xunit;
using FluentAssertions;
using System.Linq.Expressions;

namespace TddByExampleTests
{
    public class MoneyTests
    {
        [Fact]
        public void TestDollarMultiplication()
        {
            Money five = Money.Dollar(5);
            five.Times(2).Should().BeEquivalentTo(Money.Dollar(10));
            five.Times(3).Should().BeEquivalentTo(Money.Dollar(15));
        }

        [Fact]
        public void TestFrancMultiplication()
        {
            var five = Money.Franc(5);
            five.Times(2).Should().BeEquivalentTo(Money.Franc(10));
            five.Times(3).Should().BeEquivalentTo(Money.Franc(15));
        }

        [Fact]
        public void TestEquality()
        {
            Money.Dollar(5).Equals(Money.Dollar(5)).Should().Be(true);
            Money.Dollar(5).Equals(Money.Dollar(6)).Should().Be(false);
            Money.Franc(5).Equals(Money.Dollar(5)).Should().Be(false);
        }
        
        [Fact]
        public void TestCurrency()
        {
            Money.Dollar(1).GetCurrency().Should().Be("USD");
            Money.Franc(1).GetCurrency().Should().Be("CHF");
        }

        [Fact]
        public void TestSimpleAddition()
        {
            var five = Money.Dollar(5);
            var sum = five.Plus(Money.Dollar(5));
            var bank = new Bank();
            var reduced = bank.Reduce(sum, "USD");
            reduced.Should().BeEquivalentTo(Money.Dollar(10));
        }

        [Fact]
        public void TestPlusReturnsSum()
        {
            var five = Money.Dollar(5);
            var result = five.Plus(five);
            var sum = (Sum)result;
            sum.Augend.Should().BeEquivalentTo(five);
            sum.Addend.Should().BeEquivalentTo(five);
        }

        [Fact]
        public void TestReduceSum()
        {
            var sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            var bank = new Bank();
            var result = bank.Reduce(sum, "USD");
            
            result.Should().BeEquivalentTo(Money.Dollar(7));
        }

        [Fact]
        public void TestReduceMoney()
        {
            var bank = new Bank();
            var result = bank.Reduce(Money.Dollar(1), "USD");

            result.Should().BeEquivalentTo(Money.Dollar(1));
        }

        [Fact]
        public void TestReduceMoneyDifferentCurrency()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            var result = bank.Reduce(Money.Franc(2), "USD");
            result.Should().BeEquivalentTo(Money.Dollar(1));
        }

        [Fact]
        public void TestIdentityRate()
        {
            new Bank().GetRate("USD", "USD").Should().Equals(1);
        }
    }
}
