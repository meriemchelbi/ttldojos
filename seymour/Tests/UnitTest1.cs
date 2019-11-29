using System;
using NSubstitute;
using seymour.Services;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void UseTestDouble()
        {
            var weatherService = new WeatherService(new MyTestDouble());

            var message = weatherService.GetMessage();

            Assert.Equal("MyReading:42", message);
        }

        [Fact]
        public void UseNSub()
        {
            var meteor = NSubstitute.Substitute.For<IMeteorologicalService>();

            meteor.GetReading().Returns(42);

            var weatherService = new WeatherService(meteor);

            var message = weatherService.GetMessage();

            Assert.Equal("MyReading:42", message);
        }
    }

    public class MyTestDouble : IMeteorologicalService
    {
        public int GetReading()
        {
            return 42;
        }
    }
}
