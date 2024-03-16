## Logger Library Usage Guidelines:
This guide provides comprehensive instructions on how to use the Logger Library within your applications. Follow these steps to configure the library, set up logging sinks, and start logging messages.

## Getting Started:
1. Installation
Before you can use the Logger Library, you need to include it in your project. If the library is packaged as a NuGet package, you can add it via the NuGet Package Manager. Alternatively, if you're using the library from source, ensure that the library project is referenced by your application project.

2. Initializing the Logger
The first step in using the Logger Library is to create an instance of the Logger class. This instance will be the central point for all your logging operations.

```csharp 
var logger = new Logger();
```
## Configuring Sinks:
A "sink" is a destination for your log messages, such as the console or a file. You must configure one or more sinks to determine where your log messages will be outputted.

- Console Sink:
To log messages to the console, create an instance of ConsoleSink and add it to your logger.
```csharp 
var consoleSink = new ConsoleSink();
logger.AddSink(consoleSink);
```
- File Sink
To log messages to a file, create an instance of FileSink with the desired file path and add it to your logger.
```csharp 
var fileSink = new FileSink("path/to/your/logfile.log");
logger.AddSink(fileSink);
```
## Writing Log Messages
With the logger configured, you can start logging messages. Create instances of the Message class and pass them to the logger's Log method.

```csharp 
var debugMessage = new Message("This is a debug message", LogLevel.DEBUG, "Application");
logger.Log(debugMessage);

var errorMessage = new Message("This is an error message", LogLevel.ERROR, "Database");
logger.Log(errorMessage);
```

## Advanced Configuration
Custom Sinks
You can extend the Logger Library by implementing custom sinks. To create a custom sink, implement the ISink interface and define the behavior in the Log method.

```csharp 
public class CustomSink : ISink
{
    public void Log(Message message)
    {
        // Custom logging behavior
    }
}
// Add the custom sink to the logger
var customSink = new CustomSink();
logger.AddSink(customSink);
```

## Filtering Messages:
If you need to filter messages based on their level or other criteria, you can implement this logic within your custom sink or by extending the Logger class.

## Troubleshooting:
Common Issues:
- Messages not appearing: Ensure that you've added at least one sink to your logger and that the sink is correctly configured.
- Performance issues: Logging can be I/O intensive, especially with file sinks. Consider logging asynchronously or reducing the verbosity of logged messages.

## Getting Help
If you encounter issues that you can't resolve, consider checking the library's FAQ or reaching out to the community forums or the issue tracker of the project repository.

## Conclusion
The Logger Library is a powerful tool for adding logging capabilities to your applications. By following these guidelines, you should be able to effectively integrate the library into your projects and customize it to fit your needs.