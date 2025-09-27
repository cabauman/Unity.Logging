using NUnit.Framework;
using System;
using System.IO;

namespace GameCtor.ULogging
{
    public class LogFormatterTests
    {
        [Test]
        public void SourceLogFormatter()
        {
            // Arrange
            var sut = new SourceLogFormatter();
            var mockClock = new MockClock { Now = DateTime.Now };
            sut.Clock = mockClock;
            var filePath = Path.Combine("MyFilePath", "MyFile.cs");

            // Act
            var actual = sut.GetFormattedString(ULogLevel.Debug, "TestTest", null, "MyMethod", filePath, 42);

            // Assert
            var expectedTimestamp = mockClock.Now.ToString(sut._timestampFormat);
            Assert.That(actual, Is.EqualTo($"{mockClock.Now.ToString(sut._timestampFormat)} DEBUG [MyFile.cs::MyMethod::42]-> TestTest"));
        }

        [Test]
        public void PlainLogFormatter()
        {
            // Arrange
            var sut = new PlainLogFormatter();
            var filePath = Path.Combine("MyFilePath", "MyFile.cs");

            // Act
            var actual = sut.GetFormattedString(ULogLevel.Debug, "TestTest", null, "MyMethod", filePath, 42);

            // Assert
            Assert.That(actual, Is.EqualTo("TestTest"));
        }

        [Test]
        public void JsonLogFormatter()
        {
            // Arrange
            var sut = new JsonLogFormatter();
            var mockClock = new MockClock { Now = DateTime.Now };
            sut.Clock = mockClock;
            var filePath = Path.Combine("MyFilePath", "MyFile.cs");

            // Act
            var actual = sut.GetFormattedString(ULogLevel.Debug, "TestTest", null, "MyMethod", filePath, 42);

            // Assert
            var expected = @$"{{
  ""Timestamp"": ""{mockClock.Now.ToString(sut._timestampFormat)}"",
  ""Level"": ""DEBUG"",
  ""FileName"": ""MyFile.cs"",
  ""MemberName"": ""MyMethod"",
  ""LineNumber"": 42,
  ""Message"": ""TestTest"",
  ""Payload"": null
}}";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void EditorLogFormatter()
        {
            // Arrange
            var sut = new EditorLogFormatter();
            var filePath = Path.Combine("MyFilePath", "MyFile.cs");

            // Act
            var message = sut.GetFormattedString(ULogLevel.Debug, "TestTest", null, "MyMethod", filePath, 42);

            // Assert
            var expected = $"DEBUG [<a href=\"{filePath}\" line=\"42\">MyFile.cs::MyMethod::42</a>]-> TestTest";
            Assert.That(message, Is.EqualTo(expected));
        }
    }
}
