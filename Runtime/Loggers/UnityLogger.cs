using System.Runtime.CompilerServices;

namespace GameCtor.ULogging
{
    /// <summary>
    /// A wrapper around Unity's Debug.Log* methods.
    /// </summary>
    public sealed class UnityLogger : BaseLogger
    {
        public UnityLogger(ILogFormatter formatter) : base(formatter)
        {
        }

        public override void Error(
            string message,
            UnityEngine.Object context = null,
            object payload = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            if (Level < ULogLevel.Error)
            {
                return;
            }

            message = _formatter.GetFormattedString(ULogLevel.Error, message, payload, memberName, filePath, lineNumber);
            UnityEngine.Debug.LogError(message, context);
        }

        public override void Warn(
            string message,
            UnityEngine.Object context = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            if (Level < ULogLevel.Warn)
            {
                return;
            }

            message = _formatter.GetFormattedString(ULogLevel.Warn, message, null, memberName, filePath, lineNumber);
            UnityEngine.Debug.LogWarning(message, context);
        }

        public override void Info(
            string message,
            UnityEngine.Object context = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            if (Level < ULogLevel.Info)
            {
                return;
            }

            message = _formatter.GetFormattedString(ULogLevel.Info, message, null, memberName, filePath, lineNumber);
            UnityEngine.Debug.Log(message, context);
        }

        public override void Debug(
            string message,
            UnityEngine.Object context = null,
            object payload = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            if (Level < ULogLevel.Debug)
            {
                return;
            }

            message = _formatter.GetFormattedString(ULogLevel.Debug, message, payload, memberName, filePath, lineNumber);
            UnityEngine.Debug.Log(message, context);
        }

        public override void Trace(
            string message,
            UnityEngine.Object context = null,
            object payload = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            if (Level < ULogLevel.Trace)
            {
                return;
            }

            message = _formatter.GetFormattedString(ULogLevel.Trace, message, payload, memberName, filePath, lineNumber);
            UnityEngine.Debug.Log(message, context);
        }
    }
}
