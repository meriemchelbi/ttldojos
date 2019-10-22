using System;
using System.Collections.Generic;
using System.Text;

namespace LCDDigitsProgram.LCDDigits.service
{
    public interface IOrchestrateLCDConversion
    {
        bool ConvertStringToLCD();
    }
    class LCDConversionOrchestrator: IOrchestrateLCDConversion
    {
        private readonly InputCapturer _inputCapturer;
        private readonly LCDConverter _lcdConverter;
        private readonly OutputRenderer _outputRenderer;

        
        public LCDConversionOrchestrator()
        {
            _inputCapturer = new InputCapturer();
            _lcdConverter = new LCDConverter();
            _outputRenderer = new OutputRenderer();
        }

        public bool ConvertStringToLCD()
        {
            var userInput = _inputCapturer.GetUserInput();
            var result = _lcdConverter.LookupLCDNotation(userInput);
            var outcome = _outputRenderer.RenderResult(userInput, result);
            return outcome;
        }

    }
}
