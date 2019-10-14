using System.Collections.Generic;

namespace DiamondKata.domain
{
    public interface IMatrix
    {
        string[,] Matrix { get; }
        int MatrixWidth { get; }
    }

    public class DiamondMatrix: IMatrix
    {
        public string[,] Matrix { get; }
        public int MatrixWidth { get; }

        public DiamondMatrix(int inputIndex)
        {
            MatrixWidth = ComputeMatrixSize(inputIndex);
            Matrix = GenerateMatrix();
        }

        private int ComputeMatrixSize(int inputIndex)
        {
            var matrixWidth = (inputIndex * 2) + 1;
            return matrixWidth;
      
        }

        private string[,] GenerateMatrix()
        {
            var blankMatrix = new string[MatrixWidth, MatrixWidth];
            return blankMatrix;
        }
                    
    }

}