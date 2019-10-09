using DiamondKata.service;
using System;

namespace DiamondKata
{
    // interface here IUserInterfaceService
    public class UserInterfaceSvc
    {
        OrchestrationSvc managementSvc;
        public void Play(OrchestrationSvc ManagementSvc)
        {
            managementSvc = ManagementSvc;
            var letter = CaptureLetter();
            var matrix = managementSvc.Start(letter);
            RenderInput(matrix);
        }
        public LetterLookupSvc CaptureLetter()
	    {
            var letter = RequestInput();
            var letterLookup = new LetterLookupSvc(letter);
            return letterLookup;

        }

        private string RequestInput()
        {
            Console.WriteLine("Enter a letter > ");
            var letter = Console.ReadLine();
            return letter;
        }

        public void RenderInput(string[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine($"{matrix[i, j]} {i}, {j}");
                }
            }
        }

    }


}