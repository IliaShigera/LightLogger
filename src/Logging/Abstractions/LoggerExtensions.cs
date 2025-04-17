namespace Logging.Abstractions;

public static class LoggerExtensions
{
    public static void LogInfo(this ILogger logger, string message) =>
        logger.Log(message, LogLv.Info);


    public static void LogWarning(this ILogger logger, string message) =>
        logger.Log(message, LogLv.Warning);

    public static void LogError(this ILogger logger, string message, Exception? ex = null) =>
        logger.Log(
            ex == null
                ? message
                : $"{message}\nException: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}",
            LogLv.Error);
}