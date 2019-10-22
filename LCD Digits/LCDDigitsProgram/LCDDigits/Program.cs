using LCDDigitsProgram.LCDDigits.service;
using System;

namespace LCDDigits
{
    class Program
    {
        static readonly LCDConversionOrchestrator _lcdDigitsOrchestrator = new LCDConversionOrchestrator();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                running = _lcdDigitsOrchestrator.ConvertStringToLCD();
            }
            
        }
    }
}
