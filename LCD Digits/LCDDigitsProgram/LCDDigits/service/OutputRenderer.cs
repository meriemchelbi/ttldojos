using System;
using System.Collections.Generic;
using System.Text;

namespace LCDDigitsProgram.LCDDigits.service
{
    public class OutputRenderer
    {
        internal bool RenderResult(string userInput, Dictionary<int, Dictionary<int, string>> lcdCollection)
        {
            if (userInput == "Q")
            {
                Console.WriteLine("\nSo long, sucker!");
                return false;
            }
            else
            {
                RenderCollection(lcdCollection);
                return true;
            }

            
        }

        private void RenderCollection(Dictionary<int, Dictionary<int, string>> lcdCollection)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < lcdCollection.Count; j++)
                {
                    var letter = lcdCollection[j];
                    Console.Write($"{letter[i]} ");
                }

                Console.WriteLine("\r");
            }
            
        }
    }
}
