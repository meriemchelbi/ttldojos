using LCDDigitsProgram.LCDDigits.service;
using System;

namespace LCDDigits
{
    class Program
    {
        static readonly LCDDigitsOrchestrator _lcdDigitsOrchestrator = new LCDDigitsOrchestrator();

        static void Main(string[] args)
        {

            _lcdDigitsOrchestrator.StringToLCD();

        }
    }
}
