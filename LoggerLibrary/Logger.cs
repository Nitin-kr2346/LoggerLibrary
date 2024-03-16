using LoggerLibrary.Interface;
using LoggerLibrary.Model;
using System.Collections.Generic;

namespace LoggerLibrary
{
    /// <summary>
    /// The Logger class is the central component of the logger library, managing different logging sinks
    /// and routing log messages to them based on configuration.
    /// </summary>
    public class Logger
    {
        private readonly List<ISink> sinks = new List<ISink>();

        /// <summary>
        /// Adds a new sink to the logger.
        /// </summary>
        /// <param name="_sink">The sink to add. It must implement the ISink interface.</param>
        public void AddSink(ISink _sink)
        {
            sinks.Add(_sink);
        }

        /// <summary>
        /// Logs a message to all configured sinks. The method determines which sinks are appropriate
        /// for the message's level and sends the message to them.
        /// </summary>
        /// <param name="message">The message to log. The message contains the content, level, and namespace.</param>
        public void Log(Message message)
        {
            foreach (var sink in sinks)
            {
                sink.Log(message);
            }
        }
    }
}
