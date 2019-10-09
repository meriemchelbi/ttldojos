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
        public void TestLetterIndexLookup(string chosenLetter, int expectedChosenLetterIndex)
        {
            // arrange & act
            LetterLookupSvc lookup = new LetterLookupSvc(chosenLetter);
            var expectedMatrixLettersLength = expectedChosenLetterIndex + 1;

            // assert
            Assert.Equal(chosenLetter, lookup.ChosenLetter);
            Assert.Equal(expectedChosenLetterIndex, lookup.ChosenLetterAlphabetIndex);
            Assert.Equal(expectedMatrixLettersLength, lookup.MatrixLetters.Length);
            
        }

    }
}
