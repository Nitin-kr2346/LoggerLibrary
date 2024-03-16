## Logger Library Class Structure:
This document provides a detailed overview of the classes and interfaces that make up the Logger Library. The library is designed with modularity and extensibility in mind, allowing for easy customization and expansion.

## Overview:
The Logger Library consists of several key components that work together to provide a flexible and powerful logging solution. These components include the Logger class, Message class, LogLevel enumeration, ISink interface, and various Sink implementations.

### Class and Interface Descriptions:

## LogLevel Enumeration
- Description: Represents the severity level of a log message.
- Values:
	> DEBUG: Detailed information typically of interest only when diagnosing problems.
	> INFO: Informational messages that highlight the progress of the application.
	> WARN: Potentially harmful situations.
	> ERROR: Error events that might still allow the application to continue running.
	> FATAL: Very severe error events that will presumably lead the application to abort.

## Message Class
- Description: Encapsulates a log message, including its content, level, and namespace.
- Properties:
- Content: The text of the log message.
- Level: The severity level of the message (from LogLevel enumeration).
- Namespace: Identifies the part of the application where the log message originated.

## ISink Interface
- Description: Defines a contract for sink implementations that specify how log messages are outputted or stored.
- Methods:
	> Log(Message message): Outputs or stores a given log message.

## ConsoleSink Class
- Implements: ISink
- Description: A sink implementation that writes log messages to the console.
- Behavior: Utilizes the Console.WriteLine method to output log messages, formatting them with their level, namespace, and content.

## FileSink Class
- Implements: ISink
- Description: A sink implementation that writes log messages to a specified file.
- Behavior: Writes log messages to a file, appending each message on a new line. If the file does not exist, it is created.

## Logger Class
- Description: The central class of the library that clients interact with to log messages.
- Behavior: Manages a collection of ISink instances and routes log messages to them based on the message level.
- Methods:
	> AddSink(ISink sink): Adds a new sink to the logger.
	> Log(Message message): Logs a message by routing it to all configured sinks.

## Relationships
The Logger class aggregates ISink instances, allowing for multiple sinks to be used simultaneously. Each sink can be an instance of any class that implements the ISink interface, such as ConsoleSink or FileSink.
The Logger class is the primary entry point for clients of the library. Clients create log messages and pass them to the Logger, which then uses the configured sinks to output or store the messages.
The Message class is used throughout the library as the standard way to encapsulate log information, including the message content, its level, and the namespace it belongs to.
The LogLevel enumeration is used by the Message class to specify the severity of a log message.

## Extending the Library
To extend the library with new Sink implementations, developers can create new classes that implement the ISink interface and define their custom logging behavior in the Log method. After implementing a new sink, it can be added to a Logger instance using the AddSink method, allowing for flexible and customizable logging configurations.