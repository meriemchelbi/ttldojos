using System;
using System.Collections.Generic;
using System.Text;

namespace LCDDigitsProgram.LCDDigits.domain
{
    // should this be a struct?
    public class LCDCharacterRepository
    {
        public Dictionary<char, Dictionary<int, string>> LCDDigits { get; }

        private readonly Dictionary<int, string> _lcdZero;
        private readonly Dictionary<int, string> _lcdOne;
        private readonly Dictionary<int, string> _lcdTwo;
        private readonly Dictionary<int, string> _lcdThree;
        private readonly Dictionary<int, string> _lcdFour;
        private readonly Dictionary<int, string> _lcdFive;
        private readonly Dictionary<int, string> _lcdSix;
        private readonly Dictionary<int, string> _lcdSeven;
        private readonly Dictionary<int, string> _lcdEight;
        private readonly Dictionary<int, string> _lcdNine;

        public LCDCharacterRepository()
        {
            _lcdZero = new Dictionary<int, string>
            {
                { 0, "._." },
                { 1, "|.|" },
                { 2, "|_|" },
            };

            _lcdOne = new Dictionary<int, string>
            {
                { 0, "..." },
                { 1, "..|" },
                { 2, "..|" },
            };

            _lcdTwo = new Dictionary<int, string>
            {
                { 0, "._." },
                { 1, "._|" },
                { 2, "|_." },
            };

            _lcdThree = new Dictionary<int, string>
            {
                { 0, "._." },
                { 1, "._|" },
                { 2, "._|" },
            };


            _lcdFour = new Dictionary<int, string>
            {
                { 0, "..." },
                { 1, "|_|" },
                { 2, "..|" },
            };

            _lcdFive = new Dictionary<int, string>
            {
                { 0, "._." },
                { 1, "|_." },
                { 2, "._|" },
            };

            _lcdSix = new Dictionary<int, string>
            {
                { 0, "._." },
                { 1, "|_." },
                { 2, "|_|" },
            };

            _lcdSeven = new Dictionary<int, string>
            {
                { 0, "._." },
                { 1, "..|" },
                { 2, "..|" },
            };

            _lcdEight = new Dictionary<int, string>
            {
                { 0, "._." },
                { 1, "|_|" },
                { 2, "|_|" },
            };

            _lcdNine = new Dictionary<int, string>
            {
                { 0, "._." },
                { 1, "|_|" },
                { 2, "..|" },
            };


            LCDDigits = new Dictionary<char, Dictionary<int, string>>
            {
                {'0', _lcdZero },
                {'1', _lcdOne },
                {'2', _lcdTwo },
                {'3', _lcdThree },
                {'4', _lcdFour },
                {'5', _lcdFive },
                {'6', _lcdSix },
                {'7', _lcdSeven },
                {'8', _lcdEight },
                {'9', _lcdNine },
            };
        }
    }
}
