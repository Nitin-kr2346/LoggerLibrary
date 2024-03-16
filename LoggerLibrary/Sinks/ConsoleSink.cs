using LoggerLibrary.Interface;
using LoggerLibrary.Model;
using System;

namespace LoggerLibrary.Sinks
{
    /// <summary>
    /// Represents a sink that logs messages to the console. This sink is useful for real-time monitoring of log messages,
    /// typically during development or for applications running in a console environment where immediate output is necessary.
    /// </summary>
    public class ConsoleSink : ISink
    {
        /// <summary>
        /// Logs a message to the console.
        /// </summary>
        /// <param name="message">The <see cref="Message"/> to be logged. Contains the log level, namespace, and content
        /// of the message.</param>
        /// <remarks>
        /// This method formats the message to include the log level and namespace before outputting to the console,
        /// making it easier to distinguish the severity and source of the message at a glance.
        /// </remarks>
        public void Log(Message message)
        {
            Console.WriteLine($"[{message.Level}] {message.Namespace}: {message.Content}");
        }
    }
}
