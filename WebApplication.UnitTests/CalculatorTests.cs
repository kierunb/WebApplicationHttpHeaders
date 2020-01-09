using System;
using WebApplicationHttpHeaders;
using Xunit;
using FluentAssertions;

namespace WebApplication.UnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_CorrectNumbersProvided_CorrectResult()
        {
            // kazdy test jednostokowy ma następującą strukturę:
            // AAA - Arrange, Act, Assert

            // Arrange - "Aranżacja testu"
            var calc = new Calculator();
            int x = 2;
            int y = 2;
            int expectedResult = 4;

            // Act - działamy - czyli odpalamy test
            int actual_result = calc.Add(x, y);

            // Assert -> Sprawdzenie naszego zalozenia
            // Definiujemy warunek poprawnosci naszego testu
            Assert.Equal(expectedResult, actual_result);

        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(3, 3, 6)]
        [InlineData(0, 0, 0)]

        public void Add_CorrectNumbersProvided_CorrectResults(int x, int y, int result)
        {
            var calc = new Calculator();

            // zamiast tak:
            //Assert.Equal(result, calc.Add(x, y));

            // można tak:
            calc.Add(x, y).Should().Be(result);
        }

        [Fact]
        public void Divide_ByZero_Should_ThrowException()
        {
            var calc = new Calculator();

            Action act = () => calc.Divide(6, 0);

            act.Should().Throw<Exception>();

        }
    }
}
