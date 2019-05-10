using FluentAssertions;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using System;

namespace ReversePolishCalculator
{
    [ExcludeFromCodeCoverage]
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Add_Success()
        {
            var calc = new Calculator();
            var first = 12;
            var second = 12;
            var result = calc.Add(first, second);
            result.Should().Be(24, "Because addition...");
        }

        [Fact]
        public void Calculator_Subtract_Success()
        {
            var calc = new Calculator();
            var first = 13;
            var second = 12;
            var result = calc.Subtract(first, second);
            result.Should().Be(1, "Because subtraction...");
        }

        [Fact]
        public void Calculator_Divide_Success()
        {
            var calc = new Calculator();
            var first = 12;
            var second = 4;
            var result = calc.Divide(first, second);
            result.Should().Be(3, "Because division...");
        }

        [Fact]
        public void Calculator_Divide_Failure()
        {
            var calc = new Calculator();
            var first = 4;
            var second = 0;
            Assert.Throws<ArgumentException>(() => calc.Divide(first, second));
        }

        [Fact]
        public void Calculator_Multiply_Success()
        {
            var calc = new Calculator();
            var first = 3;
            var second = 4;
            var result = calc.Multiply(first, second);
            result.Should().Be(12, "Because multiplication...");
        }

        [Fact]
        public void Calculator_Power_Success()
        {
            var calc = new Calculator();
            var first = 2;
            var second = 3;
            var result = calc.Power(first, second);
            result.Should().Be(8, "Because powers...");
        }
    }
}
