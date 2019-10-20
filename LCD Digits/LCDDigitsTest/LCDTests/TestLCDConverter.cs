using System;
using Xunit;
using LCDDigitsProgram.LCDDigits.service;
using LCDDigitsProgram.LCDDigits.domain;
using System.Collections.Generic;

namespace LCDTests
{
    public class TestLCDConverter
    {
        [Theory]
        [InlineData('0', "._.", "|.|", "|_|")]
        [InlineData('1', "...", "..|", "..|")]
        [InlineData('2', "._.", "._|", "|_.")]
        [InlineData('3', "._.", "._|", "._|")]
        [InlineData('4', "...", "|_|", "..|")]
        [InlineData('5', "._.", "|_.", "._|")]
        [InlineData('6', "._.", "|_.", "|_|")]
        [InlineData('7', "._.", "..|", "..|")]
        [InlineData('8', "._.", "|_|", "|_|")]
        [InlineData('9', "._.", "|_|", "..|")]
        public void TestConvertSingleDigit(char digitInput, string line1, string line2, string line3)
        {
            var lcdConverter = new LCDConverter();
            var expected = new Dictionary<int, string>
            {
                { 0, line1 },
                { 1, line2 },
                { 2, line3 },
            };

            var actual = lcdConverter.ConvertSingleDigit(digitInput);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
           
        }

        [Theory]
        [InlineData("56", 2)]
        [InlineData("125", 3)]
        [InlineData("3", 1)]
        [InlineData("7684", 4)]
        [InlineData("93775", 5)]
        public void TestConvertToLCD(string input, int outputCount)
        {
            // arrgange
            var lcdConverter = new LCDConverter();

            // act
            var actual = lcdConverter.ConvertToLCD(input);

            // assert
            Assert.Equal(outputCount, actual.Count);
        }
    }
}
