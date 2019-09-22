using Xunit;

namespace RomanNumerals
{

    public class UnitTest1
    {
        public string AsRoman(int value)
        {
            string result = "";
            if(value >= 10)
            {
                value -= 10;
                result += "X";
            }

            if (value >= 5)
            {
                value -= 5;
                result = "V";
            }

            if(value == 4)
            {
                value = value - 4;
                result += "IV";
            }

            for (int i = 1; i <= value; i++)
            {
                
                result += "I";

            }

                
            return result;
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(8, "VIII")]
        [InlineData(11, "XI")]
        [InlineData(14, "XIV")]
        [InlineData(38, "XXXVIII")]
        public void Given1_ReturnsI(int input, string expected)
        {
            var roman = AsRoman(input);
            Assert.Equal(expected, roman);
        }
    }
}
