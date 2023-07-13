using static ExtraGraphicsSettings.Settings;

namespace ExtraGraphicsSettings
{
    /// <summary>
    /// A standardized logger class
    /// </summary>
    /// <remarks>
    /// Available Functions:                                            <br/>
    /// <c>Log(string message, params object[] parameters)</c>          <br/>
    /// <c>LogWarning(string message, params object[] parameters)</c>   <br/>
    /// <c>LogError(string message, params object[] parameters)</c>     <br/>
    /// <c>LogSeperator(params object[] parameters)</c>                 <br/>
    /// <c>LogStarter()</c>                                             <br/>
    /// <c>LogDebugOnly(string message)</c>
    /// </remarks>
    public class Logger
    {
        /// <summary>
        /// Standard logger
        /// </summary>
        /// <param name="message">The log message you want to send</param>
        /// <param name="parameters">MelonLoader logger params. Things like Color.white can be used here</param>
        public static void Log(string message, params object[] parameters)              => Melon<ExtraGraphicsSettings>.Logger.Msg($"{message}", parameters);
        /// <summary>
        /// Provides a log using the warning preset
        /// </summary>
        /// <param name="message">The log message you want to send</param>
        /// <param name="parameters">MelonLoader logger params. Things like Color.white can be used here</param>
        public static void LogWarning(string message, params object[] parameters)       => Melon<ExtraGraphicsSettings>.Logger.Warning($"{message}", parameters);
        /// <summary>
        /// Provides a log using the Error preset
        /// </summary>
        /// <param name="message">The log message you want to send</param>
        /// <param name="parameters">MelonLoader logger params. Things like Color.white can be used here</param>
        public static void LogError(string message, params object[] parameters)         => Melon<ExtraGraphicsSettings>.Logger.Error($"{message}", parameters);
        /// <summary>
        /// Provides a standard log separator, should you need it
        /// </summary>
        /// <param name="parameters">MelonLoader logger params. Things like Color.white can be used here</param>
        public static void LogSeperator(params object[] parameters)                     => Melon<ExtraGraphicsSettings>.Logger.Msg("==============================================================================", parameters);
        /// <summary>
        /// This log allows you to log your mod starting. However it is deprecated and shouldnt be used in any form
        /// </summary>
        [Obsolete("Using this function is no longer needed as MelonLoader already logs the identical info")]
        public static void LogStarter()                                                 => Melon<ExtraGraphicsSettings>.Logger.Msg($"Mod loaded with v{BuildInfo.Version}");
        /// <summary>
        /// Logging debug only info
        /// </summary>
        /// <param name="message">The log message you want to send</param>
        public static void LogDebugOnly(string message)
        {
            Color orange = new Vector4(255, 165, 0, 1);
            if (!Instance.DebugEnabled) return;
            else
            {
                Log(message, orange);
            }
        }
    }
}