using System;

namespace GameCtor.ULogging
{
    /// <summary>
    /// A base formatter class that provides a timestamp helper.
    /// </summary>
    public abstract class BaseLogFormatter : ILogFormatter
    {
        protected internal readonly string _timestampFormat = "HH:mm:ss";

        public BaseLogFormatter(string timestampFormat)
        {
            _timestampFormat = timestampFormat;
        }

        internal IClock Clock { private get; set; } = new SystemClock();

        public abstract string GetFormattedString(
            ULogLevel logLevel,
            string message,
            object payload,
            string memberName,
            string filePath,
            int lineNumber);

        protected virtual DateTime GetTimestamp() => Clock.Now;

        protected virtual string GetTimestampString() => Clock.Now.ToString(_timestampFormat);
    }
}
