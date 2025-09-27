using System.Runtime.CompilerServices;

namespace GameCtor.ULogging
{
    /// <summary>
    /// A utility class for logging.
    /// </summary>
#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad]
#endif
    public static class ULog
    {
        private static ULogConfig _config;
        private static BaseLogger[] _loggers;

        public static ULogLevel Level
        {
            get => _config.Level;
            set
            {
                _config.Level = value;
                foreach (var logger in _loggers)
                {
                    logger.Level = value;
                }
            }
        }

        static ULog()
        {
            // Assign a fallback logger for the case when ULog is used before Init is called.
#if UNITY_EDITOR
            var loggers = new BaseLogger[] { new UnityLogger(new EditorLogFormatter()) };
#else
            var loggers = new BaseLogger[] { new UnityLogger(new SourceLogFormatter()) };
#endif
            _config = new ULogConfig()
            {
                Level = ULogLevel.Trace,
                Loggers = loggers,
            };

            _loggers = _config.Loggers;
            Level = _config.Level;
        }

        public static void Init(ULogConfig config)
        {
            UnityEngine.Debug.Assert(config != null, "Tried to initialize ULog with a null config instance");
            UnityEngine.Debug.Assert(config.Loggers != null, "Loggers weren't assigned to the ULog instance");

            _config = config;
            _loggers = config.Loggers;
            Level = _config.Level;
        }

        public static void Error(
            string message,
            UnityEngine.Object context = null,
            object payload = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            for (int i = 0; i < _loggers.Length; i++)
            {
                _loggers[i].Error(message, context, payload, memberName, filePath, lineNumber);
            }
        }

#if ULOG_DISABLE_LOGGING
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void Warn(
            string message,
            UnityEngine.Object context = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            for (int i = 0; i < _loggers.Length; i++)
            {
                _loggers[i].Warn(message, context, memberName, filePath, lineNumber);
            }
        }

#if ULOG_DISABLE_LOGGING
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void Info(
            string message,
            UnityEngine.Object context = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            for (int i = 0; i < _loggers.Length; i++)
            {
                _loggers[i].Info(message, context, memberName, filePath, lineNumber);
            }
        }

#if ULOG_DISABLE_LOGGING
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void Debug(
            string message,
            UnityEngine.Object context = null,
            object payload = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            for (int i = 0; i < _loggers.Length; i++)
            {
                _loggers[i].Debug(message, context, payload, memberName, filePath, lineNumber);
            }
        }

#if ULOG_DISABLE_LOGGING
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void Trace(
            string message,
            UnityEngine.Object context = null,
            object payload = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            for (int i = 0; i < _loggers.Length; i++)
            {
                _loggers[i].Trace(message, context, payload, memberName, filePath, lineNumber);
            }
        }
    }
}
