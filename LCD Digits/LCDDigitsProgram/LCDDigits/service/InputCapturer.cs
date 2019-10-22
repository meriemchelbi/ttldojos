using System;
using System.Collections.Generic;
using System.Text;

namespace LCDDigitsProgram.LCDDigits.service
{
    public interface ICaptureInput
    {

    }
    class InputCapturer
    {
        public string GetUserInput()
        {
            Console.WriteLine("\nPlease enter a number... any number. Or enter Q to quit.");
            var userInput = Console.ReadLine().ToUpper();

            return userInput;
        }
    }
}
