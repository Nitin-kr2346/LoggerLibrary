using LoggerLibrary.Model;

namespace LoggerLibrary.Interface
{
    /// <summary>
    /// Defines the interface for log sinks. Implement this interface to create new sink types.
    /// </summary>
    public interface ISink
    {
        void Log(Message message);
    }
}
