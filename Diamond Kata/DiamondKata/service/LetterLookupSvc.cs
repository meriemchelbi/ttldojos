using DiamondKata.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiamondKata.service
{
    // Interface

    public class LetterLookupSvc
    {
       
        // Property: Selected letter, get & set
        public string Letter { get; private set; }
        public int LetterIndex { get; private set; }

        public LetterLookupSvc(string letter)
        {
            Letter = letter;
            LookUpLetterIndex(letter);
        }

        private void LookUpLetterIndex(string letter)
        {
            var alphabet = new Letters();
            LetterIndex = Array.IndexOf(alphabet.Alphabet, letter);
        }

    }
}
