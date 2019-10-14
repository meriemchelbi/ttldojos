using DiamondKata.domain;
using System;

namespace DiamondKata.service
{
    // interface?
    public class OrchestrationSvc
    {
        LetterLookupSvc letterLookup; 
        Matrix blankMatrix;
        string[,] matrix;
        MatrixPopulator matrixPopulator;

        public OrchestrationSvc()
        {
            matrixPopulator = new MatrixPopulator();
        }
               
     
        public string[,] Start(LetterLookupSvc letter)
        {
            letterLookup = letter;
            var letterIndex = letterLookup.ChosenLetterAlphabetIndex;
            blankMatrix = new Matrix(letterIndex);
            matrix = blankMatrix.BlankMatrix;
            matrixPopulator.PopulateMatrix(matrix, letter);
            
            return matrix;

        }



    }

}
