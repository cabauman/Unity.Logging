namespace GameCtor.ULogging
{
    /// <summary>
    /// A formatter that simply returns the message string.
    /// </summary>
    public sealed class PlainLogFormatter : BaseLogFormatter
    {
        public PlainLogFormatter(string timestampFormat = "HH:mm:ss") : base(timestampFormat)
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
            return message;
        }
    }
}
