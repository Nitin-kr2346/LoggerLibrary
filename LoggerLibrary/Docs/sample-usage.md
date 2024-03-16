## Sample Usage
Integrating and utilizing the logger library within your application involves initializing the logger, configuring it with the desired sinks, and logging messages at various levels. Here are examples to get you started.

## Initializing the Logger
```csharp
var logger = new Logger();
logger.AddSink(new ConsoleSink());
logger.AddSink(new FileSink("app.log"));
```
## Logging Messages
```csharp
// Logging an informational message
logger.Log(new Message("Application start", LogLevel.INFO, "Startup"));

// Logging a debug message
logger.Log(new Message("Debugging output", LogLevel.DEBUG, "Debug"));

// Logging an error message
logger.Log(new Message("An error occurred", LogLevel.ERROR, "Error"));
```