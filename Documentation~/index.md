# About ULogging

A minimalistic logging solution.

## Requirements

- Unity 2020.3 LTS or higher

<a name="installation"></a>
## Installation

<a name="using-ulogging"></a>
## Using ULogging

### Features

- Can strip logging from builds using the ULOG_DISABLE_LOGGING scripting define symbol.
- The file name, method name, and line number are available to all log messages without reflection by using caller information attributes interpreted by the C# compiler.
- Error, Debug, and Trace logging support payloads in which all properties and fields of a provided object get serialized to json format.
- Static ULog utility class for convenient access.
- Formatting logic (`BaseLogFormatter`) separated from log destination logic (`BaseLogger`).

### Log Levels

- **None:** disables logging
- **Error:** indicates error conditions that impair some operation
- **Warn:** signifies potential issues that may lead to errors or unexpected behavior in the future if not addressed
- **Info:** includes messages that provide a record of the normal operation of the system, e.g. successful initialization, services starting and stopping, logged in/out, or successful completion of significant transactions
- **Debug:** intended for logging detailed information about the system for troubleshooting, e.g. logging request/response payloads, dumping object state
- **Trace:** used like breadcrumbs to track what steps lead to an error state; usually placed at the start of a method and includes the arguments, e.g. “Confirm button clicked”

### Included Loggers

- UnityLogger: a wrapper for UnityEngine.Debug.Log* methods

### Included Formatters

- Editor: includes markup that can be displayed in the Unity log console; includes clickable hyperlink to the source line
- Json: outputs in json format by Json.NET
- Plain: outputs only the raw message (no formatting applied)
- Source: `{timestamp} {logLevel} [{fileName}::{memberName}::{lineNumber}]-> {message}{payload}`

### Instructions

A logger and formatter are configured by default (`UnityLogger` and `SourceLogFormatter`), so there's no setup required. If you'd like to customize, read on.
Otherwise, you can skip ahead to [Example Usage](#example-usage).

#### Logger Config

1. Instantiate a formatter and logger.
2. Pass them to a `ULogConfig` object and specify a log level.
3. Pass the config to `ULog.Init`.

```csharp
[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
public static void Init()
{
    var logger = new FileLogger(new JsonLogFormatter());
    var config = new ULogConfig
    {
        Level = ULogLevel.Info,
        Loggers = new BaseLogger[] { logger },
    };
    ULog.Init(config);
}
```

<a name="example-usage"></a>
### Example Usage

```csharp
public void DoSomething(string name, Vector3 myVector)
{
    // 'context' corresponds to the 'context' parameter of UnityEngine.Debug.Log
    ULog.Trace("args:", context: this, payload: new { name, myVector });
}

/*
TRACE [LoggingSample.cs::DoSomething::26]-> args:
payload: {
  "name": "Colt",
  "myVector": {
    "magnitude": 1.0,
    "sqrMagnitude": 1.0,
    "x": 1.0,
    "y": 0.0,
    "z": 0.0
  }
*/
```

```csharp
ULog.Error("An error occurred", payload: ex);

/*
ERROR [LoggingSample.cs::Start::35]-> An error occurred
payload: {
  "ClassName": "System.InvalidOperationException",
  "Message": "Test Exception",
  "Data": null,
  "InnerException": null,
  "HelpURL": null,
  "StackTraceString": "  at ULogging.Samples.LoggingSample.ErrorMethod () [0x00001] in .\\Packages\\com.gamector.ulogging\\Samples\\LoggingSample.cs:41 \r\n  at ULogging.Samples.LoggingSample.Start () [0x0001f] in .\\Packages\\com.gamector.ulogging\\Samples\\LoggingSample.cs:30 ",
  "RemoteStackTraceString": null,
  "RemoteStackIndex": 0,
  "ExceptionMethod": null,
  "HResult": -2146233079,
  "Source": "Sol.Logging.Samples"
}
*/
```

```csharp
// JSON formatter
ULog.Debug("Hello World!", context: this, payload: new { Name });

/*
{
  "Timestamp": "16:35:19",
  "Level": "DEBUG",
  "FileName": "LoggingSample.cs",
  "MemberName": "Start",
  "LineNumber": 26,
  "Message": "Hello World!",
  "Payload": {
    "Name": "Colt"
  }
}
*/
```

<a name="Samples"></a>
## Samples

- [LoggingSample](sample.md)
