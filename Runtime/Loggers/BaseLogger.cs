using System.Runtime.CompilerServices;

namespace GameCtor.ULogging
{
    /// <summary>
    /// A contract for custom logger implementations to follow. Only controls log destinations; not formatting.
    /// </summary>
    /// <remarks>
    /// NOTE (only relevant for users that choose to reference loggers directly,
    /// as opposed to using the static <see cref="ULog"/> class):
    /// Derived classes do not need to define the ULOG_DISABLE_LOGGING conditional compilation check
    /// because it gets inherited from this class.
    /// </remarks>
    public abstract class BaseLogger
    {
        protected readonly ILogFormatter _formatter;

        public ULogLevel Level { get; set; } = ULogLevel.Info;

        public BaseLogger(ILogFormatter formatter)
        {
            _formatter = formatter;
        }

        public abstract void Error(
            string message,
            UnityEngine.Object context = null,
            object payload = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0);

#if ULOG_DISABLE_LOGGING
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public abstract void Warn(
            string message,
            UnityEngine.Object context = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0);

#if ULOG_DISABLE_LOGGING
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public abstract void Info(
            string message,
            UnityEngine.Object context = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0);

#if ULOG_DISABLE_LOGGING
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public abstract void Debug(
            string message,
            UnityEngine.Object context = null,
            object payload = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0);

#if ULOG_DISABLE_LOGGING
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public abstract void Trace(
            string message,
            UnityEngine.Object context = null,
            object payload = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0);
    }
}
