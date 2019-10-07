using DiamondKata.domain;
using System;

namespace DiamondKata.service
{
    // interface?
    public class ManagementSvc
    {
        // properties/fields (declare)
        LetterLookupSvc letterConvertorService; // provides us with letter & its index in alphabet
        Matrix blankMatrix;
        char[,] matrix;
        MatrixPopulator matrixPopulator;

        // constructor?

        
     
        public char[,] Start(LetterLookupSvc letter)
        {
            letterConvertorService = letter;
            var letterIndex = letterConvertorService.LetterIndex;
            
            // instantiate _matrix
            // get blank matrix & assign to public class variable
            // Call MatrixPopulator with matrix instance as parameter
            
            return matrix;

        }



    }

}
