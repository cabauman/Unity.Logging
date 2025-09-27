using System.IO;
using static GameCtor.ULogging.ULogFormatHelpers;

namespace GameCtor.ULogging
{
    /// <summary>
    /// A formatter that utilizes markup that can be displayed in the Unity log console.
    /// This includes clickable hyperlinks to the source code, colors, font-weight, etc.
    /// The basic format is: {logLevel} [{fileName}::{memberName}::{lineNumber}]-> {message}{payload}
    /// </summary>
    public sealed class EditorLogFormatter : BaseLogFormatter
    {
        public EditorLogFormatter(string timestampFormat = "HH:mm:ss") : base(timestampFormat)
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
            string str = $"{levelLabel} [<a href=\"{filePath}\" line=\"{lineNumber}\">{fileName}::{memberName}::{lineNumber}</a>]-> {message}{payloadString}";

            return str;
        }
    }
}
