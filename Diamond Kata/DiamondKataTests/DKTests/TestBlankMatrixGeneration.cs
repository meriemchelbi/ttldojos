using DiamondKata.domain;
using System;
using Xunit;

namespace DKTests
{
    public class TestBlankMatrixGeneration
    {

        [Theory]
        [InlineData(2, 5)]
        [InlineData(9, 19)]
        public void TestMatrixDimensionsCalculation(int letterIndex, int width)
        {
            var matrix = new DiamondMatrix(letterIndex);

            Assert.Equal(width, matrix.MatrixWidth);

        }

        [Theory]
        [InlineData(2, 5)]
        [InlineData(9, 19)]
        public void TestMatrixGeneratedWithCorrectDimensions(int letterIndex, int width)
        {
            var matrix = new DiamondMatrix(letterIndex);

            // row width/dimension length
            Assert.Equal(width, matrix.Matrix.GetLength(0));
            // column height/dimension length
            Assert.Equal(width, matrix.Matrix.GetLength(1));

        }


    }
}
