using System;
using System.Collections.Generic;
using System.Text;

namespace LCDDigitsProgram.LCDDigits.service
{
    public interface IConvertToLCD
    {

    }
    public class LCDConverter
    {
        public IEnumerable<char> ConvertToLCD(string userInput)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> ConvertSingleDigit(char letterInput)
        {
            throw new NotImplementedException();
        }
    }
}
