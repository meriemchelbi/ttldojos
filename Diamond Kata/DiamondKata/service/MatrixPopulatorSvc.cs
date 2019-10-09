using System;

namespace DiamondKata.service
{

    public class MatrixPopulator
    {

        public void PopulateMatrix(string[,] matrix, LetterLookupSvc letter)
        {
            PopulateBlanks(matrix);
            PopulateLetters(matrix, letter);
        }

        private void PopulateBlanks(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = "  ";
                }
            }
        }

        public void PopulateLetters(string[,] matrix, LetterLookupSvc letter)
        {
            var horizontalIndex = (int)(matrix.GetLength(0) / 2);
            var verticalIndex = 0;
            matrix[verticalIndex, horizontalIndex] = "A";
            var verticalIndexBottom = (matrix.GetLength(1) - 1);
            matrix[verticalIndexBottom, horizontalIndex] = "A";

            var letters = letter.MatrixLetters;

            for (int i = 1; i < letter.MatrixLetters.Length; i++)
            {
                verticalIndex++;
                var selectedLetter = letters[i];
                matrix[verticalIndex, (horizontalIndex - i)] = selectedLetter;
                matrix[verticalIndex, (horizontalIndex + i)] = selectedLetter;

                verticalIndexBottom -= 1;
                matrix[verticalIndexBottom, (horizontalIndex - i)] = selectedLetter;
                matrix[verticalIndexBottom, (horizontalIndex + i)] = selectedLetter;
            }

        }

    }


}
