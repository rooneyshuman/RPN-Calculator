using System;
using FileLogger;
using FluentAssertions;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using FakeItEasy;

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
        public void RpnEngine_Divide_Failure()
        {
            var rpnEngine = new RpnEngine();
            var input = "6 0 /";
            Assert.Throws<ArgumentException>(() => rpnEngine.CalculateRpn(input));
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
        public void RpnEngine_Exception_Thrown()
        {
            var rpnEngine = new RpnEngine();
            var input = "2 3 ]";
            Assert.Throws< ArgumentException >(() => rpnEngine.CalculateRpn(input));
        }

        [Fact]
        public void RpnEngine_Exception_Call_To_Log()
        {
            var calc = A.Fake<Calculator>();
            var log = A.Fake<Logger>();
            var rpnEngine = new RpnEngine(calc, log);
            var input = "2 3 ]";
            Assert.Throws<ArgumentException>(() => rpnEngine.CalculateRpn(input));
            A.CallTo(() => log.Fatal("Could not parse []]")).MustHaveHappened();
        }

        [Fact]
        public void RpnEngine_Result_Call_To_Log()
        {
            var calc = A.Fake<Calculator>();
            var log = A.Fake<Logger>();
            var rpnEngine = new RpnEngine(calc, log);
            var input = "2 3 +";
            rpnEngine.CalculateRpn(input);
            A.CallTo(() => log.Debug("Result of calculation is [5]")).MustHaveHappened();
        }
    }
}
