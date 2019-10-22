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
        [InlineData("56", 2, "._.", "|_.", "._|", "._.", "|_.", "|_|")]
        [InlineData("125", 3, "...", "..|", "..|", "._.", "|_.", "._|")]
        [InlineData("3", 1, "._.", "._|", "._|", "._.", "._|", "._|")]
        [InlineData("7684", 4, "._.", "..|", "..|", "...", "|_|", "..|")]
        [InlineData("93775", 5, "._.", "|_|", "..|", "._.", "|_.", "._|")]
        public void TestLookupLCDNotation(string input, int outputCount, string firstLine1, string firstLine2, string firstLine3, string lastLine1, string lastLine2, string lastLine3)
        {
            // arrange
            var lcdConverter = new LCDConverter();

            // act
            var actual = lcdConverter.LookupLCDNotation(input);

            // assert result contains correct number of digits
            Assert.Equal(outputCount, actual.Count);
            
            // assert that first LCD digit matches expected values
            var firstDigit = actual[0];
            Assert.Equal(firstLine1, firstDigit[0]);
            Assert.Equal(firstLine2, firstDigit[1]);
            Assert.Equal(firstLine3, firstDigit[2]);

            // assert that last LCD digit matches expected values
            var lastDigit = actual[actual.Count - 1];
            Assert.Equal(lastLine1, lastDigit[0]);
            Assert.Equal(lastLine2, lastDigit[1]);
            Assert.Equal(lastLine3, lastDigit[2]);
        }
    }
}
