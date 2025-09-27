using System.Collections.Generic;

namespace GameCtor.ULogging
{
    public sealed class TestLogFormatter : BaseLogFormatter
    {
        public TestLogFormatter(string timestampFormat = "HH:mm:ss") : base(timestampFormat)
        {
        }

        public int ReceivedCount => LogEntries.Count;
        public List<LogEntry> LogEntries { get; private set; } = new();

        public override string GetFormattedString(
            ULogLevel logLevel,
            string message,
            object payload,
            string memberName,
            string filePath,
            int lineNumber)
        {
            LogEntries.Add(new LogEntry
            {
                LogLevel = logLevel,
                Message = message,
                Payload = payload,
                MemberName = memberName,
                FilePath = filePath,
                LineNumber = lineNumber
            });

            return message;
        }
    }

    public struct LogEntry
    {
        public ULogLevel LogLevel { get; set; }
        public string Message { get; set; }
        public object Payload { get; set; }
        public string MemberName { get; set; }
        public string FilePath { get; set; }
        public int LineNumber { get; set; }
    }
}
