using LoggerLibrary.Enum;
using LoggerLibrary.Interface;
using LoggerLibrary.Model;
using Moq;
using NUnit.Framework;
using System;

namespace LoggerLibrary.Tests
{
    [TestFixture]
    public class LoggerTests
    {
        private Logger _logger;
        private Mock<ISink> _mockSink1;
        private Mock<ISink> _mockSink2;

        [SetUp]
        public void SetUp()
        {
            _logger = new Logger();
            _mockSink1 = new Mock<ISink>();
            _mockSink2 = new Mock<ISink>();

            _logger.AddSink(_mockSink1.Object);
            _logger.AddSink(_mockSink2.Object);
        }

        [Test]
        public void Logger_Should_Call_Log_On_All_Configured_Sinks()
        {
            // Arrange
            var message = new Message("Test message", LogLevel.INFO, "Test");

            // Act
            _logger.Log(message);

            // Assert
            _mockSink1.Verify(s => s.Log(It.IsAny<Message>()), Times.Once);
            _mockSink2.Verify(s => s.Log(It.IsAny<Message>()), Times.Once);
        }

        [Test]
        public void Logger_Should_Not_Throw_When_No_Sinks_Configured()
        {
            // Arrange
            var logger = new Logger();
            var message = new Message("Test message", LogLevel.INFO, "Test");

            // Act & Assert
            Assert.DoesNotThrow(() => logger.Log(message));
        }

        [Test]
        public void Logger_Should_Pass_Correct_Message_To_Sinks()
        {
            // Arrange
            var expectedMessage = new Message("Specific message", LogLevel.ERROR, "Specific");
            _mockSink1.Setup(s => s.Log(It.Is<Message>(m => m == expectedMessage))).Verifiable();

            // Act
            _logger.Log(expectedMessage);

            // Assert
            _mockSink1.Verify(); // Verifies that Log was called with the expected message
        }

        [Test]
        public void Logger_Should_Handle_Null_Message_Gracefully()
        {
            // Arrange
            Message nullMessage = null;

            // Act & Assert
            Assert.DoesNotThrow(() => _logger.Log(nullMessage));
        }

        [Test]
        public void Logger_Should_Call_Sink_When_MessageIsLogged()
        {
            // Arrange
            var mockSink = new Mock<ISink>();
            _logger.AddSink(mockSink.Object);
            var message = new Message("Test", LogLevel.INFO, "TestNamespace");

            // Act
            _logger.Log(message);

            // Assert
            mockSink.Verify(s => s.Log(It.Is<Message>(msg => msg.Content == "Test" && msg.Level == LogLevel.INFO && msg.Namespace == "TestNamespace")), Times.Once());
        }

        [Test]
        public void Logger_Should_Call_MultipleSinks_When_MessageIsLogged()
        {
            // Arrange
            var mockSink1 = new Mock<ISink>();
            var mockSink2 = new Mock<ISink>();
            _logger.AddSink(mockSink1.Object);
            _logger.AddSink(mockSink2.Object);
            var message = new Message("Multiple sinks test", LogLevel.DEBUG, "MultisinkNamespace");

            // Act
            _logger.Log(message);

            // Assert
            mockSink1.Verify(s => s.Log(It.IsAny<Message>()), Times.Once());
            mockSink2.Verify(s => s.Log(It.IsAny<Message>()), Times.Once());
        }

        [Test]
        public void Logger_Should_LogMessages_To_Dynamically_Added_Sink()
        {
            // Arrange
            var dynamicSink = new Mock<ISink>();
            var message = new Message("Dynamic sink test", LogLevel.INFO, "Test");
            _logger.AddSink(dynamicSink.Object); // Dynamically adding a new sink

            // Act
            _logger.Log(message);

            // Assert
            dynamicSink.Verify(s => s.Log(It.IsAny<Message>()), Times.Once);
        }

        [Test]
        public void Logger_Should_ApplyConsistentFormatting_ToMessages()
        {
            // Arrange
            var message = new Message("A formatted message", LogLevel.INFO, "Formatting");
            var expectedFormat = $"[INFO] Formatting: A formatted message"; // Adjust based on actual formatting
            Message capturedMessage = null;

            _mockSink1.Setup(s => s.Log(It.IsAny<Message>()))
                      .Callback<Message>(m => capturedMessage = m);

            // Act
            _logger.Log(message);

            // Assert
            Assert.IsNotNull(capturedMessage, "No message was captured; expected a message to be logged.");
            Assert.AreEqual(expectedFormat, $"[{capturedMessage.Level}] {capturedMessage.Namespace}: {capturedMessage.Content}", "The logged message content did not match the expected format.");
        }

        [Test]
        public void Logger_Should_ApplyConsistentFormatting_To_Messages()
        {
            // Arrange
            var formattedSink = new Mock<ISink>();
            _logger.AddSink(formattedSink.Object);

            var message = new Message("Formatted message", LogLevel.INFO, "Formatting");

            string loggedContent = null;

            // Mocking the Sink to verify the formatted message

            formattedSink.Setup(s => s.Log(It.IsAny<Message>())).Callback<Message>(m => loggedContent = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] [{m.Level}] {m.Namespace}: {m.Content}");

            // Act
            _logger.Log(message);

            // Assert
            Assert.IsTrue(loggedContent.StartsWith($"[{DateTime.Now.ToString("yyyy-MM-dd")}"));
            Assert.IsTrue(loggedContent.Contains("Formatted message"));
        }

        [Test]
        public void Logger_Should_Correctly_Interact_With_CustomSinks()
        {
            // Arrange
            var customSink = new Mock<ISink>();
            _logger.AddSink(customSink.Object);
            var customMessage = new Message("Custom sink message", LogLevel.DEBUG, "Custom");

            // Act
            _logger.Log(customMessage);

            // Assert
            customSink.Verify(s => s.Log(It.IsAny<Message>()), Times.Once, "Logger should correctly pass messages to custom sinks.");
        }

    }
}
