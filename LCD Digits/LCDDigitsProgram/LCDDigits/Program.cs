using LCDDigitsProgram.LCDDigits.service;
using System;

namespace LCDDigits
{
    class Program
    {
        static readonly LCDDigitsOrchestrator _lcdDigitsOrchestrator = new LCDDigitsOrchestrator();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                running = _lcdDigitsOrchestrator.StringToLCD();
            }
            
        }
    }
}
