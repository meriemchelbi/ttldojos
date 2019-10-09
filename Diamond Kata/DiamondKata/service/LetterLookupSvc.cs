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
        public string ChosenLetter { get; private set; }
        public int ChosenLetterAlphabetIndex { get; private set; }
        private readonly Letters alphabet = new Letters();


        // can this be a list? Implement via interface?
        public string[] MatrixLetters { get; private set; }

        public LetterLookupSvc(string chosenLetter)
        {
            ChosenLetter = chosenLetter;
            LookUpChosenLetterIndex(chosenLetter);
            SetMatrixLetters();
        }

        private void LookUpChosenLetterIndex(string chosenLetter)
        {
            ChosenLetterAlphabetIndex = Array.IndexOf(alphabet.Alphabet, chosenLetter);
        }

        private void SetMatrixLetters()
        {
            MatrixLetters = new string[ChosenLetterAlphabetIndex + 1];
            for (int i = 0; i < (ChosenLetterAlphabetIndex + 1); i++)
            {
                MatrixLetters[i] = alphabet.Alphabet[i];
            }
        }

    }
}
