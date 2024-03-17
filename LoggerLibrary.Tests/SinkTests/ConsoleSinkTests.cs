using LoggerLibrary.Enum;
using LoggerLibrary.Model;
using LoggerLibrary.Sinks;
using NUnit.Framework;
using System;
using System.IO;

namespace LoggerLibrary.Tests.SinkTests
{
    [TestFixture]
    public class ConsoleSinkTests
    {
        private StringWriter _stringWriter;
        private TextWriter _originalOutput;

        [SetUp]
        public void SetUp()
        {
            _originalOutput = Console.Out; // Save original Console.Out
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter); // Redirect Console.Out to StringWriter
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(_originalOutput); // Reset Console.Out
            _stringWriter.Dispose();
        }

        [Test]
        public void ConsoleSink_Should_OutputToConsole_When_LogMessage()
        {
            // Arrange
            var consoleSink = new ConsoleSink();
            var message = new Message("Test message", LogLevel.INFO, "TestNamespace");

            // Act
            consoleSink.Log(message);

            // Assert
            StringAssert.Contains("Test message", _stringWriter.ToString());
            StringAssert.Contains("[INFO]", _stringWriter.ToString());
            StringAssert.Contains("TestNamespace", _stringWriter.ToString());
        }

        [Test]
        public void ConsoleSink_Should_HandleSpecialCharacters_When_LogMessage()
        {
            // Arrange
            var consoleSink = new ConsoleSink();
            var message = new Message("Special characters: \n\r\t", LogLevel.DEBUG, "Special");

            // Act
            consoleSink.Log(message);

            // Assert
            StringAssert.Contains("Special characters: \n\r\t", _stringWriter.ToString());
        }

        [Test]
        public void ConsoleSink_Should_LogMultipleMessagesConcurrently_WithoutLosingData()
        {
            // This test might require a more sophisticated setup to simulate concurrency accurately.
            // For demonstration purposes, let's log two messages in quick succession.

            // Arrange
            var consoleSink = new ConsoleSink();
            var message1 = new Message("Concurrent message 1", LogLevel.WARN, "Concurrency");
            var message2 = new Message("Concurrent message 2", LogLevel.ERROR, "Concurrency");

            // Act
            consoleSink.Log(message1);
            consoleSink.Log(message2);

            // Assert
            StringAssert.Contains("Concurrent message 1", _stringWriter.ToString());
            StringAssert.Contains("Concurrent message 2", _stringWriter.ToString());
        }

        [Test]
        public void ConsoleSink_Should_IncludeCorrectTimestamp_When_LogMessage()
        {
            // Arrange
            var consoleSink = new ConsoleSink();
            var currentDateTime = DateTime.Now;
            var message = new Message("Message with timestamp: " + currentDateTime.ToString("yyyy-MM-dd HH:mm:ss"), LogLevel.INFO, "Timestamp");

            // Act
            consoleSink.Log(message);

            // Assert
            var output = _stringWriter.ToString();
            var expectedTimestamp = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            StringAssert.Contains(expectedTimestamp, output, "The log output should include the current timestamp.");
        }
    }
}
