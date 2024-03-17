using LoggerLibrary.Interface;
using LoggerLibrary.Model;
using System;
using System.IO;

namespace LoggerLibrary.Sinks
{
    /// <summary>
    /// Represents a sink that logs messages to a specified file.
    /// This sink allows for persistent storage of log messages, which can be useful for audit trails,
    /// error monitoring, and application diagnostics over time.
    /// </summary>
    public class FileSink : ISink
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSink"/> class with a specific file path.
        /// </summary>
        /// <param name="filePath">The full path of the file to which log messages will be written.
        /// If the file does not exist, it will be created. If it exists, messages will be appended to it.</param>
        public FileSink(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Logs a message to the file specified in the <see cref="FileSink"/> constructor.
        /// </summary>
        /// <param name="message">The <see cref="Message"/> to be logged. The message contains
        /// the log content, level, and namespace.</param>
        /// <remarks>
        /// This method appends the log message to the end of the file. Each message is written
        /// on a new line, formatted with the log level, namespace, and content for easy readability.
        /// </remarks>
        public void Log(Message message)
        {
            using (var writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] [{message.Level}] {message.Namespace}: {message.Content}");
            }
        }
    }
}
