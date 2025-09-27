namespace GameCtor.ULogging
{
    public interface ILogFormatter
    {
        public abstract string GetFormattedString(
            ULogLevel logLevel,
            string message,
            object payload,
            string memberName,
            string filePath,
            int lineNumber);
    }
}
