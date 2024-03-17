using LoggerLibrary.Enum;
using LoggerLibrary.Model;
using LoggerLibrary.Sinks;
using NUnit.Framework;
using System;
using System.IO;

namespace LoggerLibrary.Tests.SinkTests
{
    [TestFixture]
    public class FileSinkTests
    {
        private string _testFilePath;
        private FileSink _fileSink;

        [SetUp]
        public void SetUp()
        {
            // Generate a unique file name for each test to avoid conflicts
            _testFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".log");
            _fileSink = new FileSink(_testFilePath);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the test file if it exists
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [Test]
        public void FileSink_Should_WriteLogMessageToFile()
        {
            // Arrange
            var message = new Message("Test message", LogLevel.INFO, "TestNamespace");

            // Act
            _fileSink.Log(message);

            // Assert
            string fileContent = File.ReadAllText(_testFilePath);
            StringAssert.Contains("Test message", fileContent);
            StringAssert.Contains("[INFO]", fileContent);
            StringAssert.Contains("TestNamespace", fileContent);
        }

        [Test]
        public void FileSink_Should_AppendMultipleLogMessagesToFile()
        {
            // Arrange
            var message1 = new Message("First message", LogLevel.INFO, "TestNamespace");
            var message2 = new Message("Second message", LogLevel.ERROR, "TestNamespace");

            // Act
            _fileSink.Log(message1);
            _fileSink.Log(message2);

            // Assert
            string[] lines = File.ReadAllLines(_testFilePath);
            Assert.IsTrue(lines.Length >= 2, "File should contain at least two log entries.");
            StringAssert.Contains("First message", lines[0]);
            StringAssert.Contains("Second message", lines[1]);
        }

        [Test]
        public void FileSink_Should_HandleSpecialCharactersInLogMessage()
        {
            // Arrange
            var message = new Message("Special characters: \n\r\t", LogLevel.DEBUG, "Special");

            // Act
            _fileSink.Log(message);

            // Assert
            string fileContent = File.ReadAllText(_testFilePath);
            StringAssert.Contains("Special characters: \n\r\t", fileContent);
        }

        [Test]
        public void FileSink_Should_CreateLogFileIfNotExists()
        {
            // Ensure the file does not exist before test
            Assert.IsFalse(File.Exists(_testFilePath));

            // Arrange
            var message = new Message("Test message for new file", LogLevel.INFO, "Initialization");

            // Act
            _fileSink.Log(message);

            // Assert
            Assert.IsTrue(File.Exists(_testFilePath), "Log file should be created after logging the first message.");
        }
    }
}
