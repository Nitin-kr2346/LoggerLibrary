## Logger Library Architecture:
- Overview
	This document provides a detailed overview of the architecture of the Logger Library, designed to offer a flexible and extensible logging framework for .NET applications. The library allows applications to log messages with various levels of severity to multiple destinations, called sinks. It emphasizes simplicity, performance, and extensibility.

## Core Components:
The Logger Library architecture consists of several core components working together to provide comprehensive logging capabilities. These include:
	> Logger: The central component that applications interact with to log messages. It manages routing of messages to appropriate sinks based on the message level and sink configurations.
	> Message: Represents a log message with properties including the message content, level (e.g., DEBUG, INFO, WARN, ERROR, FATAL), and namespace.
	> Sink: An interface defining a destination for log messages. Implementations of this interface allow the library to log messages to various outputs such as console, file, database, or external systems.
	> LogLevel: An enumeration that defines the possible levels of log messages, used for filtering messages based on their importance.

## Component Interaction:
1. Logging Process:
- An application calls the Logger.Log method to log a message, specifying the message content, level, and namespace.
- The Logger determines which sinks are eligible for the given message based on the message level and each sink's configuration.
- The Logger forwards the message to all eligible sinks.

2. Sink Processing:
- Each sink processes the message independently. For example, a FileSink might append the message to a log file, while a ConsoleSink outputs the message to the console.
- Sinks can format the message or include additional metadata as configured.

## Extensibility
The Logger Library is designed with extensibility in mind:
	> Custom Sinks: Developers can extend the ISink interface to create custom sinks that log to new destinations.
	> Level Filtering: Sinks can be configured to filter messages based on their level, allowing for flexible log management.
	> Formatting: Custom formatting can be applied to log messages by extending the logging process within custom sinks.

## Configuration:
The Logger Library supports dynamic configuration, enabling developers to configure sinks, log levels, and other settings without modifying the application code. Configuration can be loaded from files, environment variables, or programmatically set during runtime.

## Conclusion:
The Logger Library's architecture provides a robust foundation for logging in .NET applications, offering flexibility, performance, and ease of use. By understanding the core components and their interactions, developers can effectively utilize and extend the library to meet their logging needs.