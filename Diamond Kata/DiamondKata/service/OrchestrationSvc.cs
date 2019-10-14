using DiamondKata.domain;
using System;

namespace DiamondKata.service
{
    public interface IOrchestrationSvc
    {
        string[,] Start(ILetterLookupSvc letter);
    }
    public class OrchestrationSvc: IOrchestrationSvc
    {
        private readonly MatrixPopulator _matrixPopulator;

        public OrchestrationSvc()
        {
            _matrixPopulator = new MatrixPopulator();
        }
               
     
        public string[,] Start(ILetterLookupSvc letter)
        {
            var letterLookup = letter;
            var letterIndex = letterLookup.ChosenLetterAlphabetIndex;
            var blankMatrix = new DiamondMatrix(letterIndex);
            var matrix = blankMatrix.Matrix;
            _matrixPopulator.PopulateMatrix(matrix, letter);
            
            return matrix;

        }



    }

}
