# Logger Library Class Structure

This document outlines the classes and their relationships within the Logger Library, providing insights into its architecture and how it facilitates logging functionality.

## Overview

The Logger Library is designed to offer a flexible and powerful logging system, which can be easily integrated into various types of applications. Its modular design allows for customizable logging through different sinks and levels.

## Classes and Interfaces

### LogLevel Enumeration

- **Description**: Defines the severity levels of log messages.
- **Members**:
  - `DEBUG`: Detailed information, typically of interest only when diagnosing problems.
  - `INFO`: Confirmation that things are working as expected.
  - `WARN`: An indication that something unexpected happened, or indicative of some problem in the near future.
  - `ERROR`: Due to a more serious problem, the software has not been able to perform some function.
  - `FATAL`: A severe error that causes the program to abort.

### Message Class

- **Description**: Represents a log message, encapsulating all details about the message being logged.
- **Properties**:
  - `Content`: The text of the log message.
  - `Level`: The severity level (`LogLevel`) of the log message.
  - `Namespace`: The namespace from which the log message originated, helping categorize and filter log messages.

### ISink Interface

- **Description**: Defines the functionality for a logging sink, which is a destination for log messages.
- **Method**:
  - `Log(Message message)`: Logs the provided message to the sink's specific destination (e.g., console, file, etc.).

### ConsoleSink Class

- **Implements**: `ISink`
- **Description**: A sink that outputs log messages to the console.
- **Method Implementation**:
  - `Log(Message message)`: Writes the message to the standard output.

### FileSink Class

- **Implements**: `ISink`
- **Description**: A sink that writes log messages to a specified file.
- **Constructor Parameters**:
  - `filePath`: The path to the file where log messages will be written.
- **Method Implementation**:
  - `Log(Message message)`: Appends the message to the specified log file.

### Logger Class

- **Description**: The main class that applications interact with to perform logging.
- **Properties**:
  - `Sinks`: A collection of `ISink` instances to which the logger will send log messages.
- **Methods**:
  - `AddSink(ISink sink)`: Adds a new sink to the logger.
  - `Log(Message message)`: Logs a message to all configured sinks, based on the message's level.

## Usage

The logger is initialized and configured by adding sinks, after which messages can be logged through it using the `Log` method. The flexibility of the sink system allows for logging to multiple destinations, customizable by the application's needs.

## Extending the Library

To extend the library with new sink types, implement the `ISink` interface and add instances of the new sink to the logger using the `AddSink` method. This design allows for easy expansion and integration of custom logging functionalities.

