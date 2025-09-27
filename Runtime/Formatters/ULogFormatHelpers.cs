using Newtonsoft.Json;
using System.Collections.Generic;

namespace GameCtor.ULogging
{
    /// <summary>
    /// Convenient helpers for formatting logs.
    /// </summary>
    public static class ULogFormatHelpers
    {
        public static readonly Dictionary<ULogLevel, string> LevelToLabelMap = new()
        {
            { ULogLevel.Error, "ERROR" },
            { ULogLevel.Warn, "WARN" },
            { ULogLevel.Info, "INFO" },
            { ULogLevel.Debug, "DEBUG" },
            { ULogLevel.Trace, "TRACE" },
        };

        public static JsonSerializerSettings JsonSerializerSettings { get; set; } = new()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new JsonDumpContractResolver(),
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
            Formatting = Formatting.Indented,
        };

        public static string GetPayloadString(object payload, string prefix = "")
        {
            var payloadString = "";
            if (payload != null)
            {
                payloadString = prefix + JsonConvert.SerializeObject(
                    payload,
                    JsonSerializerSettings);
            }

            return payloadString;
        }
    }
}
