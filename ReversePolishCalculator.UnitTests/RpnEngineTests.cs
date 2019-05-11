using System;
using FileLogger;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using FakeItEasy;

namespace ReversePolishCalculator
{ 
    [ExcludeFromCodeCoverage]
    public class RpnEngineTests
    {
        [Fact]
        public void RpnEngine_Call_To_Add()
        {
            var calc = A.Fake<Calculator>();
            var log = A.Fake<Logger>();
            var rpnEngine = new RpnEngine(calc, log);
            var input = "2 3 +";
            rpnEngine.CalculateRpn(input);
            A.CallTo(() => calc.Add(3, 2)).MustHaveHappened();
        }

        [Fact]
        public void RpnEngine_Call_To_Subtract()
        {
            var calc = A.Fake<Calculator>();
            var log = A.Fake<Logger>();
            var rpnEngine = new RpnEngine(calc, log);
            var input = "4 3 -";
            rpnEngine.CalculateRpn(input);
            A.CallTo(() => calc.Subtract(4, 3)).MustHaveHappened();
        }

        [Fact]
        public void RpnEngine_Call_To_Multiply()
        {
            var calc = A.Fake<Calculator>();
            var log = A.Fake<Logger>();
            var rpnEngine = new RpnEngine(calc, log);
            var input = "2 3 *";
            rpnEngine.CalculateRpn(input);
            A.CallTo(() => calc.Multiply(3, 2)).MustHaveHappened();
        }

        [Fact]
        public void RpnEngine_Call_To_Divide()
        {
            var calc = A.Fake<Calculator>();
            var log = A.Fake<Logger>();
            var rpnEngine = new RpnEngine(calc, log);
            var input = "4 2 /";
            rpnEngine.CalculateRpn(input);
            A.CallTo(() => calc.Divide(4, 2)).MustHaveHappened();
        }

        [Fact]
        public void RpnEngine_Call_To_Power()
        {
            var calc = A.Fake<Calculator>();
            var log = A.Fake<Logger>();
            var rpnEngine = new RpnEngine(calc, log);
            var input = "2 3 ^";
            rpnEngine.CalculateRpn(input);
            A.CallTo(() => calc.Power(2, 3)).MustHaveHappened();
        }

        [Fact]
        public void RpnEngine_Exception_Thrown()
        {
            var calc = A.Fake<Calculator>();
            var log = A.Fake<Logger>();
            var rpnEngine = new RpnEngine(calc, log);
            var input = "2 3 ]";
            Assert.Throws<ArgumentException>(() => rpnEngine.CalculateRpn(input));
        }

        [Fact]
        public void RpnEngine_Exception_Call_To_Log_Fatal()
        {
            var calc = A.Fake<Calculator>();
            var log = A.Fake<Logger>();
            var rpnEngine = new RpnEngine(calc, log);
            var input = "2 3 ]";
            Assert.Throws<ArgumentException>(() => rpnEngine.CalculateRpn(input));
            A.CallTo(() => log.Fatal("Could not parse []]")).MustHaveHappened();
        }

        [Fact]
        public void RpnEngine_Result_Call_To_Log_Debug()
        {
            var calc = A.Fake<Calculator>();
            var log = A.Fake<Logger>();
            var rpnEngine = new RpnEngine(calc, log);
            var input = "0 0 +";
            rpnEngine.CalculateRpn(input);
            A.CallTo(() => log.Debug("Result of calculation is [0]")).MustHaveHappened();
        }
    }
}
