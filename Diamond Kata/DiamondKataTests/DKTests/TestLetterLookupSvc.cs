using DiamondKata.service;
using Xunit;

namespace DKTests
{
    public class TestLetterLookupSvc
    {
        [Theory]
        [InlineData("A", 0)]
        [InlineData("G", 6)]
        [InlineData("M", 12)]
        [InlineData("O", 14)]
        [InlineData("T", 19)]
        [InlineData("Z", 25)]
        public void TestLetterIndexLookup(string letter, int expectedIndex)
        {
            // arrange & act
            LetterLookupSvc indexLookup = new LetterLookupSvc(letter);

            // assert
            Assert.Equal(letter, indexLookup.Letter);
            Assert.Equal(expectedIndex, indexLookup.LetterIndex);
        }

    }
}
