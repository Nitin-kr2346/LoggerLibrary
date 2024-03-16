# Logger Library Architecture

This document provides an overview of the architecture of the Logger Library, explaining the key components and their interactions. The Logger Library is designed to offer a flexible, easy-to-use logging system that can be integrated into various software projects.

## Overview

The Logger Library's architecture is built around the core concept of log messages being sent to one or more destinations, known as "sinks". The library is designed to be modular, allowing developers to easily add or remove logging destinations and to control the verbosity of logging through log levels.

## Core Components

### Logger

- **Description**: The central component of the library, responsible for managing sinks and dispatching log messages to them.
- **Responsibilities**:
  - Collecting log messages from the application.
  - Applying global log level filters.
  - Distributing log messages to configured sinks.

### Log Message

- **Description**: Represents the data structure of a log message.
- **Components**:
  - `Content`: The actual text message to be logged.
  - `Level`: The severity level (e.g., DEBUG, INFO, WARN, ERROR, FATAL).
  - `Namespace`: An identifier to help categorize and filter messages based on the application's structure.

### Sinks

- **Description**: Abstractions for output destinations where log messages are sent.
- **Types**:
  - **ConsoleSink**: Outputs messages to the console.
  - **FileSink**: Writes messages to a specified log file.
  - **CustomSink(s)**: User-defined sinks for other destinations (e.g., databases, external systems).

### LogLevel

- **Description**: An enumeration defining the severity levels for log messages.
- **Purpose**: Allows filtering messages based on their importance or severity, both globally and at the sink level.

## Workflow

1. **Initialization**: The application configures the `Logger` instance at startup, adding desired sinks and setting the global log level if necessary.
2. **Logging**: Throughout its execution, the application sends log messages to the logger, specifying the message, its level, and the namespace.
3. **Filtering and Dispatch**: The logger filters messages based on their level, then dispatches them to the configured sinks. Each sink can have its own level filter, further refining which messages are logged.
4. **Output**: Sinks process and output the messages to their respective destinations.


## Extensibility
The Logger Library is designed with extensibility in mind:
- Custom Sinks: Developers can extend the ISink interface to create custom sinks that log to new destinations.
- Level Filtering: Sinks can be configured to filter messages based on their level, allowing for flexible log management.
- Formatting: Custom formatting can be applied to log messages by extending the logging process within custom sinks.

## Configuration:
The Logger Library supports dynamic configuration, enabling developers to configure sinks, log levels, and other settings without modifying the application code. Configuration can be loaded from files, environment variables, or programmatically set during runtime.

## Conclusion:
The Logger Library's architecture provides a robust foundation for logging in .NET applications, offering flexibility, performance, and ease of use. By understanding the core components and their interactions, developers can effectively utilize and extend the library to meet their logging needs.