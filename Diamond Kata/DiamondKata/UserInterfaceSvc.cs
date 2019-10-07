using DiamondKata.service;
using System;

namespace DiamondKata
{
    // interface here IUserInterfaceService
    public class UserInterfaceSvc
    {
        // declare private field for instance of management service
        ManagementSvc managementSvc;
        public void Play(ManagementSvc ManagementSvc)
        {
            managementSvc = ManagementSvc;
            var letter = CaptureInput();
            var matrix = managementSvc.Start(letter);
        }
        public LetterLookupSvc CaptureInput()
	    {
            Console.WriteLine("Enter a letter > ");
            var letter = Console.ReadLine();
            var letterLookup = new LetterLookupSvc(letter);
            return letterLookup;

        }

        public void RenderInput()
        {
            // take matrix as param
            // for each row in the matrix, render row & carriage return
        }

    }


}