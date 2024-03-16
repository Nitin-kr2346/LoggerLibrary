using LoggerLibrary.Enum;

namespace LoggerLibrary.Model
{
    /// <summary>
    /// Represents a log message, containing the content, level, and namespace of the message.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets the content of the log message.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Gets the level of the log message.
        /// </summary>
        /// <value>
        /// The level of the log message, indicating its severity.
        /// </value>
        public LogLevel Level { get; }

        /// <summary>
        /// Gets the namespace of the source emitting the log message.
        /// </summary>
        /// <value>
        /// The namespace associated with the log message, used to identify the part of the application that generated the message.
        /// </value>
        public string Namespace { get; }

        public Message(string content, LogLevel level, string @namespace)
        {
            Content = content;
            Level = level;
            Namespace = @namespace;
        }
    }
}
