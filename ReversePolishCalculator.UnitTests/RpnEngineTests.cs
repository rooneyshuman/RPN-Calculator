using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;
using System.Diagnostics.CodeAnalysis;

namespace ReversePolishCalculator
{ 
    [ExcludeFromCodeCoverage]
    public class RpnEngineTests
    {
        [Fact]
        public void RpnEngine_Add_Success()
        {
            var rpnEngine = new RpnEngine();
            var input = "2 2 +";
            var result = rpnEngine.CalculateRpn(input);
            result.Should().Be(4, "Because addition...");
        }

        [Fact]
        public void RpnEngine_Subtract_Success()
        {
            var rpnEngine = new RpnEngine();
            var input = "4 2 -";
            var result = rpnEngine.CalculateRpn(input);
            result.Should().Be(2, "Because subtraction...");
        }

        [Fact]
        public void RpnEngine_Multiply_Success()
        {
            var rpnEngine = new RpnEngine();
            var input = "2 3 *";
            var result = rpnEngine.CalculateRpn(input);
            result.Should().Be(6, "Because multiplication...");
        }

        [Fact]
        public void RpnEngine_Divide_Success()
        {
            var rpnEngine = new RpnEngine();
            var input = "6 2 /";
            var result = rpnEngine.CalculateRpn(input);
            result.Should().Be(3, "Because division...");
        }

        [Fact]
        public void RpnEngine_Power_Success()
        {
            var rpnEngine = new RpnEngine();
            var input = "2 3 ^";
            var result = rpnEngine.CalculateRpn(input);
            result.Should().Be(8, "Because power...");
        }

        [Fact]
        public void RpnEngine_ExceptionThrown()
        {
            var rpnEngine = new RpnEngine();
            var input = "2 3 ]";
            Assert.Throws< ArgumentException >(() => rpnEngine.CalculateRpn(input));
        }
    }
}
