using System;
using System.Collections.Generic;
using System.Text;

namespace LCDDigits.domain
{
    public class LCDDigit
    {
        private int index;
        public LCDDigit(int index)
        {
            this.index = index;

        }

        public string GetRepresentation()
        {
            return string.Empty;
        }
    }
}
