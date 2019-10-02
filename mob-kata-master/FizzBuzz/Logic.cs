using System;

namespace FizzBuzz
{
    public class Logic
    {
        public string Convert(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number));

            if (number == 0)
                return "0";

            if (number % 15 == 0)
                return "FizzBuzz";

            if (number % 5 == 0)
                return "Buzz";

            if (number % 3 == 0)
                return "Fizz";

            return number.ToString();
        }
    }
}
