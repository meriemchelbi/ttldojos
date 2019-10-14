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
        [InlineData("D", "B", 2, 4, 5)]
        [InlineData("Z", "A", 25, 25, 0)]
        [InlineData("Z", "A", 25, 25, 50)]

        public void TestPopulateMatrix(string chosenLetter, string assertLetter, int horizontalIndexLeft, int horizontalIndexRight, int verticalIndex)
        {
            // arrange
            var lookup = new LetterLookupSvc(chosenLetter);
            var matrixObject = new DiamondMatrix(lookup.ChosenLetterAlphabetIndex);
            var matrix = matrixObject.Matrix;
            var matrixPopulator = new MatrixPopulator();

            // act
            matrixPopulator.PopulateMatrix(matrix, lookup);
            
              
            // assert
            Assert.Equal(assertLetter, matrix[verticalIndex, horizontalIndexLeft]);
            Assert.Equal(assertLetter, matrix[verticalIndex, horizontalIndexRight]);
        }
    }
}
