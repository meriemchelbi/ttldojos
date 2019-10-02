using System;
using Xunit;

namespace FizzBuzz.Test
{
    /// <summary>
    /// Given:
    /// 1 2 3 4 5 6 7
    /// Returns:
    /// 1 2 Fizz 4 Buzz Fizz 7
    /// </summary>
    public class UnitTest
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void Convert_ReturnsFizz_WhenNumberIs3(int input)
        {
            // Arrange
            var fixture = new Logic();

            // Act
            var result = fixture.Convert(input);

            // Assert
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void Convert_Return4WhenInputIs4()
        {
            // Arrange
            var fixture = new Logic();

            // Act
            var result = fixture.Convert(4);

            // Assert
            Assert.Equal("4", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void Convert_ReturnBuzzWhenInputIsDivisibleBy5(int input)
        {
            // Arrange
            var fixture = new Logic();

            // Act
            var result = fixture.Convert(input);

            // Assert
            Assert.Equal("Buzz", result);
        }
        
        [Fact]
        public void Convert_ReturnFizzBuzzWhenInputIs15()
        {
            // Arrange
            var fixture = new Logic();

            // Act
            var result = fixture.Convert(15);

            // Assert
            Assert.Equal("FizzBuzz", result);
        }

        [Fact]
        public void Convert_Return1WhenInputIs1()
        {
            // Arrange
            var fixture = new Logic();

            // Act
            var result = fixture.Convert(1);

            // Assert
            Assert.Equal("1", result);
        }

        [Fact]
        public void Convert_ZeroReturnsZero()
        {
            // Arrange
            var fixture = new Logic();

            // Act
            var result = fixture.Convert(0);

            // Assert
            Assert.Equal("0", result);
        }

        [Fact]
        public void Convert_WhenNumberIsNegative_ThrowOutOfRange()
        {
            // Arrange
            var fixture = new Logic();

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => fixture.Convert(-1));
            Assert.Equal("number", exception.ParamName);
        }
    }
}
