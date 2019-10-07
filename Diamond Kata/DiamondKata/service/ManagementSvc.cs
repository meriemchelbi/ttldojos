using DiamondKata.domain;
using System;

namespace DiamondKata.service
{
    // interface?
    public class ManagementSvc
    {
        // properties/fields (declare)
        LetterLookupSvc letterLookup; // provides us with letter & its index in alphabet
        Matrix blankMatrix;
        string[,] matrix;
        MatrixPopulator matrixPopulator;

        // constructor?

        public ManagementSvc()
        {
            matrixPopulator = new MatrixPopulator();

        }
               
     
        public string[,] Start(LetterLookupSvc letter)
        {
            letterLookup = letter;
            var letterIndex = letterLookup.LetterIndex;
            blankMatrix = new Matrix(letterIndex);
            matrix = blankMatrix.BlankMatrix;
            matrixPopulator.PopulateMatrix(matrix);
            
            return matrix;

        }



    }

}
