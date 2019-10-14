using DiamondKata.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiamondKata.service
{
    public interface ILetterLookupSvc
    {
        string ChosenLetter { get; }
        int ChosenLetterAlphabetIndex { get; }
        string[] MatrixLetters { get; }
    }
    public class LetterLookupSvc: ILetterLookupSvc
    {

        public string ChosenLetter { get; }
        public int ChosenLetterAlphabetIndex { get; }
        private readonly Letters _alphabet = new Letters();
        public string[] MatrixLetters { get; }

        public LetterLookupSvc(string chosenLetter)
        {
            ChosenLetter = chosenLetter;
            ChosenLetterAlphabetIndex = LookUpChosenLetterIndex(chosenLetter);
            MatrixLetters = SetMatrixLetters();
        }

        private int LookUpChosenLetterIndex(string chosenLetter)
        {
            var chosenLetterAlphabetIndex = Array.IndexOf(_alphabet.Alphabet, chosenLetter);

            return chosenLetterAlphabetIndex;
        }

        private string[] SetMatrixLetters()
        {
            var matrixLetters = new string[ChosenLetterAlphabetIndex + 1];
            for (int i = 0; i < (ChosenLetterAlphabetIndex + 1); i++)
            {
                matrixLetters[i] = _alphabet.Alphabet[i];

            }
            return matrixLetters;

        }

    }
}
