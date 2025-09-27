using System.IO;
using static GameCtor.ULogging.ULogFormatHelpers;

namespace GameCtor.ULogging
{
    /// <summary>
    /// A formatter with the following format:
    /// {timestamp} {logLevel} [{fileName}::{memberName}::{lineNumber}]-> {message}{payload}
    /// </summary>
    public sealed class SourceLogFormatter : BaseLogFormatter
    {
        public SourceLogFormatter(string timestampFormat = "HH:mm:ss") : base(timestampFormat)
        {
        }

        public override string GetFormattedString(
            ULogLevel logLevel,
            string message,
            object payload,
            string memberName,
            string filePath,
            int lineNumber)
        {
            LevelToLabelMap.TryGetValue(logLevel, out var levelLabel);
            var start = filePath.LastIndexOf(Path.DirectorySeparatorChar) + 1;
            var fileName = filePath.Substring(start);
            string payloadString = GetPayloadString(payload, "\npayload: ");
            string str = $"{GetTimestampString()} {levelLabel} [{fileName}::{memberName}::{lineNumber}]-> {message}{payloadString}";

            return str;
        }
    }
}
