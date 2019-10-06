  using System.Collections.Generic;

namespace DiamondKata.domain
{

    public class Matrix
    {
        public char[,] BlankMatrix { get; private set; }
        public int MatrixWidth { get; private set; }

        public Matrix(int inputIndex)
        {
            ComputeMatrixSize(inputIndex);
        }

        // compute matrix size
        public void ComputeMatrixSize(int inputIndex)
        {
            MatrixWidth = (inputIndex * 2) + 1;
      
        }

        // generate blank matrix
        public void GenerateMatrix()
        {
            BlankMatrix = new char[MatrixWidth, MatrixWidth];
        }


    }

}