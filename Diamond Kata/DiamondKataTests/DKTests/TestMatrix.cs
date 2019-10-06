using DiamondKata.domain;
using System;
using Xunit;

namespace DiamondKata.test
{
    public class TestMatrix
    {

        [Theory]
        [InlineData(2, 5)]
        [InlineData(9, 19)]
        public void TestComputeMatrixSize(int letterIndex, int width)
        {
            // arrange
            var matrix = new Matrix(letterIndex);
            char[,] expectedMatrix = new char[width, width];

            // act
            matrix.ComputeMatrixSize(letterIndex);
            matrix.GenerateMatrix();


            // assert
            Assert.Equal(width, matrix.MatrixWidth);
            Assert.Equal(expectedMatrix, matrix.DiamondMatrix);

        }


    }
}
