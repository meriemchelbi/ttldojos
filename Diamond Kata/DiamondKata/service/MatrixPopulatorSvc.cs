using System;

namespace DiamondKata.service
{

    public class MatrixPopulator
    {

        public void PopulateMatrix(string[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = "wahey";
                    matrix[j, i] = "wahey";
                }
            }

        }

        public void ComputeXIndex()
        {

        }

    }


}
