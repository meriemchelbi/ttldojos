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
        public void TestMatrixGeneratedWithCorrectDimensions(int letterIndex, int width)
        {
            // arrange
            var matrix = new Matrix(letterIndex);
            // char[,] expectedMatrix = new char[width, width];

            // act
            matrix.ComputeMatrixSize(letterIndex);
            matrix.GenerateMatrix();


            // assert
            Assert.Equal(width, matrix.MatrixWidth);
            // row width/dimension length
            Assert.Equal(width, matrix.BlankMatrix.GetLength(0));
            // column height/dimension length
            Assert.Equal(width, matrix.BlankMatrix.GetLength(1));

        }


    }
}
