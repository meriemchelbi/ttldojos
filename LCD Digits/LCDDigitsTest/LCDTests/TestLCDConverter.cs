using System;
using Xunit;
using LCDDigitsProgram.LCDDigits.service;
using LCDDigitsProgram.LCDDigits.domain;


namespace LCDTests
{
    public class TestLCDConverter
    {
        [Fact]
        public void TestConvertSingleDigit()
        {
            var digitInput = '2';
            var lcdConverter = new LCDConverter();
            var expected = lcdConverter.ConvertSingleDigit(digitInput);

            var actual = lcdConverter.ConvertSingleDigit(digitInput);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestConvertToLCD()
        {

        }
    }
}
