using System.IO;
using static GameCtor.ULogging.ULogFormatHelpers;

namespace GameCtor.ULogging
{
    /// <summary>
    /// A formatter that uses the JSON.NET library to serialize the log message along with the following metadata:
    /// timestamp, log level, file name, member name, line number, and payload.
    /// </summary>
    public sealed class JsonLogFormatter : BaseLogFormatter
    {
        public JsonLogFormatter(string timestampFormat = "HH:mm:ss") : base(timestampFormat)
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

            var outputObj = new
            {
                Timestamp = GetTimestampString(),
                Level = levelLabel,
                FileName = fileName,
                MemberName = memberName,
                LineNumber = lineNumber,
                Message = message,
                Payload = payload
            };

            return GetPayloadString(outputObj);
        }
    }
}
