using DiamondKata.domain;
using DiamondKata.service;
using System;
using Xunit;


namespace DKTests
{
    public class TestMatrixPopulatorSvc
    {
        [Theory]
        [InlineData("B", "A", 1, 1, 0)]
        [InlineData("D", "B", 2, 4, 1)]
        [InlineData("Z", "A", 25, 25, 0)]

        public void TestPopulatetopHalf(string chosenLetter, string assertLetter, int expectedHorizontalIndexLeft, int expectedHorizontalIndexRight, int expectedVerticalIndex)
        {
            // arrange
            var lookup = new LetterLookupSvc(chosenLetter);
            var matrixObject = new Matrix(lookup.ChosenLetterAlphabetIndex);
            var blankMatrix = matrixObject.BlankMatrix;
            var matrixPopulator = new MatrixPopulator();

            // act
            var populatedMatrix = matrixPopulator.PopulateTopHalf(blankMatrix, lookup);
            
              
            // assert
            Assert.Equal(assertLetter, blankMatrix[expectedVerticalIndex, expectedHorizontalIndexLeft]);
            Assert.Equal(assertLetter, blankMatrix[expectedVerticalIndex, expectedHorizontalIndexRight]);
        }
    }
}
