using System;
using FileLogger;
using FluentAssertions;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using FakeItEasy;
using System.IO;

namespace ReversePolishCalculator
{
    [ExcludeFromCodeCoverage]
    public class LoggerTests
    {
        [Fact]
        public void Logger_Write_To_Log()
        {
            var logPath = @"C:\Temp\TestLog.log";
            var log = new Logger(eLogLevel.Debug);
            log.setPath(logPath);

            if (File.Exists(logPath))
                File.Delete(logPath);

            log.Fatal ("write me");
            var logFile = File.ReadAllText(logPath);
            logFile.Should().Contain("write me");

            log.Error("write me too");
            logFile = File.ReadAllText(logPath);
            logFile.Should().Contain("write me too");

            log.Warn("also write me too");
            logFile = File.ReadAllText(logPath);
            logFile.Should().Contain("also write me too");

            File.Delete(logPath);
        }

        [Fact]
        public void Logger_Dont_Write_To_Log()
        {
            var logPath = @"C:\Temp\TestLog.log";

            if (File.Exists(logPath))
                File.Delete(logPath);
            File.WriteAllText(logPath, string.Empty);

            var log = new Logger(eLogLevel.Error);
            log.setPath(logPath);
            log.Info("don't write me");
            var logFile = File.ReadAllText(logPath);

            logFile.Should().NotContain("don't write me");

            log = new Logger(eLogLevel.Warn);
            log.setPath(logPath);
            log.Debug("don't write me either");
            logFile = File.ReadAllText(logPath);

            logFile.Should().NotContain("don't write me either");

            File.Delete(logPath);
        }
    }
}
