using LCDDigits.domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LCDTests
{
    public class TestLCDDigit
    {   
        [Fact]
        public void ShouldRepresentZero()
        {
            var lcdDigit = new LCDDigit(0);

            var representation = lcdDigit.GetRepresentation();



        }


    }
}
