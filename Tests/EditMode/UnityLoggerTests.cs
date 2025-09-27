using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.TestTools;

namespace GameCtor.ULogging
{
    public sealed class UnityLoggerTests
    {
        [TestCase(ULogLevel.Trace)]
        public void TraceLogsWhenLevelIs(ULogLevel logLevel)
        {
            // Arrange
            var logMessage = "Test";
            var formatter = new TestLogFormatter();
            var sut = new UnityLogger(formatter);
            sut.Level = logLevel;
            LogAssert.Expect(LogType.Log, logMessage);

            // Act
            sut.Trace(logMessage);

            // Assert
            Assert.That(formatter.ReceivedCount, Is.EqualTo(1));
            var logEntry = formatter.LogEntries[0];
            Assert.That(logEntry.LogLevel, Is.EqualTo(ULogLevel.Trace));
            Assert.That(logEntry.Message, Is.EqualTo(logMessage));
            Assert.That(logEntry.Payload, Is.EqualTo(null));
            Assert.That(logEntry.MemberName, Is.EqualTo(nameof(TraceLogsWhenLevelIs)));
            Assert.That(logEntry.FilePath, Does.EndWith(nameof(UnityLoggerTests) + ".cs"));
            Assert.That(logEntry.LineNumber, Is.GreaterThan(0));
        }

        [TestCase(ULogLevel.Debug)]
        [TestCase(ULogLevel.Info)]
        [TestCase(ULogLevel.Warn)]
        [TestCase(ULogLevel.Error)]
        public void TraceDoesntLogWhenLevelIs(ULogLevel logLevel)
        {
            // Arrange
            var logMessage = "Test";
            var formatter = new TestLogFormatter();
            var sut = new UnityLogger(formatter);
            sut.Level = logLevel;
            LogAssert.NoUnexpectedReceived();

            // Act
            sut.Trace(logMessage);

            // Assert
            Assert.That(formatter.ReceivedCount, Is.EqualTo(0));
        }

        [TestCase(ULogLevel.Trace)]
        [TestCase(ULogLevel.Debug)]
        public void DebugLogsWhenLevelIs(ULogLevel logLevel)
        {
            // Arrange
            var logMessage = "Test";
            var formatter = new TestLogFormatter();
            var sut = new UnityLogger(formatter);
            sut.Level = logLevel;
            LogAssert.Expect(LogType.Log, logMessage);

            // Act
            sut.Debug(logMessage);

            // Assert
            Assert.That(formatter.ReceivedCount, Is.EqualTo(1));
            var logEntry = formatter.LogEntries[0];
            Assert.That(logEntry.LogLevel, Is.EqualTo(ULogLevel.Debug));
            Assert.That(logEntry.Message, Is.EqualTo(logMessage));
            Assert.That(logEntry.Payload, Is.EqualTo(null));
            Assert.That(logEntry.MemberName, Is.EqualTo(nameof(DebugLogsWhenLevelIs)));
            Assert.That(logEntry.FilePath, Does.EndWith(nameof(UnityLoggerTests) + ".cs"));
            Assert.That(logEntry.LineNumber, Is.GreaterThan(0));
        }

        [TestCase(ULogLevel.Info)]
        [TestCase(ULogLevel.Warn)]
        [TestCase(ULogLevel.Error)]
        public void DebugDoesntLogWhenLevelIs(ULogLevel logLevel)
        {
            // Arrange
            var logMessage = "Test";
            var formatter = new TestLogFormatter();
            var sut = new UnityLogger(formatter);
            sut.Level = logLevel;
            LogAssert.NoUnexpectedReceived();

            // Act
            sut.Debug(logMessage);

            // Assert
            Assert.That(formatter.ReceivedCount, Is.EqualTo(0));
        }

        [TestCase(ULogLevel.Trace)]
        [TestCase(ULogLevel.Debug)]
        [TestCase(ULogLevel.Info)]
        public void InfoLogsWhenLevelIs(ULogLevel logLevel)
        {
            // Arrange
            var logMessage = "Test";
            var formatter = new TestLogFormatter();
            var sut = new UnityLogger(formatter);
            sut.Level = logLevel;
            LogAssert.Expect(LogType.Log, logMessage);

            // Act
            sut.Info(logMessage);

            // Assert
            Assert.That(formatter.ReceivedCount, Is.EqualTo(1));
            var logEntry = formatter.LogEntries[0];
            Assert.That(logEntry.LogLevel, Is.EqualTo(ULogLevel.Info));
            Assert.That(logEntry.Message, Is.EqualTo(logMessage));
            Assert.That(logEntry.Payload, Is.EqualTo(null));
            Assert.That(logEntry.MemberName, Is.EqualTo(nameof(InfoLogsWhenLevelIs)));
            Assert.That(logEntry.FilePath, Does.EndWith(nameof(UnityLoggerTests) + ".cs"));
            Assert.That(logEntry.LineNumber, Is.GreaterThan(0));
        }

        [TestCase(ULogLevel.Warn)]
        [TestCase(ULogLevel.Error)]
        public void InfoDoesntLogWhenLevelIs(ULogLevel logLevel)
        {
            // Arrange
            var logMessage = "Test";
            var formatter = new TestLogFormatter();
            var sut = new UnityLogger(formatter);
            sut.Level = logLevel;
            LogAssert.NoUnexpectedReceived();

            // Act
            sut.Info(logMessage);

            // Assert
            Assert.That(formatter.ReceivedCount, Is.EqualTo(0));
        }

        [TestCase(ULogLevel.Trace)]
        [TestCase(ULogLevel.Debug)]
        [TestCase(ULogLevel.Info)]
        [TestCase(ULogLevel.Warn)]
        public void WarnLogsWhenLevelIs(ULogLevel logLevel)
        {
            // Arrange
            var logMessage = "Test";
            var formatter = new TestLogFormatter();
            var sut = new UnityLogger(formatter);
            sut.Level = logLevel;
            LogAssert.Expect(LogType.Warning, logMessage);

            // Act
            sut.Warn(logMessage);

            // Assert
            Assert.That(formatter.ReceivedCount, Is.EqualTo(1));
            var logEntry = formatter.LogEntries[0];
            Assert.That(logEntry.LogLevel, Is.EqualTo(ULogLevel.Warn));
            Assert.That(logEntry.Message, Is.EqualTo(logMessage));
            Assert.That(logEntry.Payload, Is.EqualTo(null));
            Assert.That(logEntry.MemberName, Is.EqualTo(nameof(WarnLogsWhenLevelIs)));
            Assert.That(logEntry.FilePath, Does.EndWith(nameof(UnityLoggerTests) + ".cs"));
            Assert.That(logEntry.LineNumber, Is.GreaterThan(0));
        }

        [TestCase(ULogLevel.Error)]
        public void WarnDoesntLogWhenLevelIs(ULogLevel logLevel)
        {
            // Arrange
            var logMessage = "Test";
            var formatter = new TestLogFormatter();
            var sut = new UnityLogger(formatter);
            sut.Level = logLevel;
            LogAssert.NoUnexpectedReceived();

            // Act
            sut.Warn(logMessage);

            // Assert
            Assert.That(formatter.ReceivedCount, Is.EqualTo(0));
        }

        [TestCase(ULogLevel.Trace)]
        [TestCase(ULogLevel.Debug)]
        [TestCase(ULogLevel.Info)]
        [TestCase(ULogLevel.Warn)]
        [TestCase(ULogLevel.Error)]
        public void ErrorLogsWhenLevelIs(ULogLevel logLevel)
        {
            // Arrange
            var logMessage = "Test";
            var formatter = new TestLogFormatter();
            var sut = new UnityLogger(formatter);
            sut.Level = logLevel;
            LogAssert.Expect(LogType.Error, logMessage);

            // Act
            sut.Error(logMessage);

            // Assert
            Assert.That(formatter.ReceivedCount, Is.EqualTo(1));
            var logEntry = formatter.LogEntries[0];
            Assert.That(logEntry.LogLevel, Is.EqualTo(ULogLevel.Error));
            Assert.That(logEntry.Message, Is.EqualTo(logMessage));
            Assert.That(logEntry.Payload, Is.EqualTo(null));
            Assert.That(logEntry.MemberName, Is.EqualTo(nameof(ErrorLogsWhenLevelIs)));
            Assert.That(logEntry.FilePath, Does.EndWith(nameof(UnityLoggerTests) + ".cs"));
            Assert.That(logEntry.LineNumber, Is.GreaterThan(0));
        }

        [TestCase(ULogLevel.Trace)]
        [TestCase(ULogLevel.Debug)]
        [TestCase(ULogLevel.Info)]
        [TestCase(ULogLevel.Warn)]
        [TestCase(ULogLevel.Error)]
        public void ErrorLogsWithExceptionWhenLevelIs(ULogLevel logLevel)
        {
            // Arrange
            var logMessage = "Test";
            var formatter = new TestLogFormatter();
            var sut = new UnityLogger(formatter);
            sut.Level = logLevel;
            var payload = new Exception("Oops");
            LogAssert.Expect(LogType.Error, logMessage);

            // Act
            sut.Error(logMessage, payload: payload);

            // Assert
            Assert.That(formatter.ReceivedCount, Is.EqualTo(1));
            var logEntry = formatter.LogEntries[0];
            Assert.That(logEntry.LogLevel, Is.EqualTo(ULogLevel.Error));
            Assert.That(logEntry.Message, Is.EqualTo(logMessage));
            Assert.That(logEntry.Payload, Is.EqualTo(payload));
            Assert.That(logEntry.MemberName, Is.EqualTo(nameof(ErrorLogsWithExceptionWhenLevelIs)));
            Assert.That(logEntry.FilePath, Does.EndWith(nameof(UnityLoggerTests) + ".cs"));
            Assert.That(logEntry.LineNumber, Is.GreaterThan(0));
        }
    }
}
