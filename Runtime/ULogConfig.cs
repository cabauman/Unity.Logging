namespace GameCtor.ULogging
{
    /// <summary>
    /// Logging configuration that can be passed to <see cref="ULog.Init"/>.
    /// </summary>
    public sealed class ULogConfig
    {
        public ULogLevel Level { get; set; } = ULogLevel.Info;
        public BaseLogger[] Loggers { get; set; }
    }
}
