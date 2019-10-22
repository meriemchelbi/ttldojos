using LCDDigitsProgram.LCDDigits.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCDDigitsProgram.LCDDigits.service
{
    public interface IConvertToLCD
    {

    }
    public class LCDConverter
    {
        private readonly LCDCharacterRepository _lcdCharacterRepository;

        public LCDConverter()
        {
            _lcdCharacterRepository = new LCDCharacterRepository();
        }
        public Dictionary<int, Dictionary<int, string>> LookupLCDNotation(string userInput)
        {
            var lcdOutput = new Dictionary<int, Dictionary<int, string>>();
            for (int i = 0; i < userInput.Length; i++)
            {
                var lcdDigit = ConvertSingleDigit(userInput[i]);
                lcdOutput.Add(i, lcdDigit);
                
            } 
            
            return lcdOutput;
        }

        public Dictionary<int, string> ConvertSingleDigit(char digitInput)
        {
            var lcdDigits = _lcdCharacterRepository.LCDDigits;
            var digitLookup = new Dictionary<int, string>();

            foreach (var digit in lcdDigits)
            {
                if (digit.Key == digitInput)
                {
                    digitLookup = digit.Value;
                    break;
                }
            }

            return digitLookup;
        }
    }
}
