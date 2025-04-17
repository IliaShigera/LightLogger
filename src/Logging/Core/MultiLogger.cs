namespace Logging.Core;

public sealed class MultiLogger : ILogger
{
    private readonly IReadOnlyList<ILogger> _loggers;

    public MultiLogger(IReadOnlyList<ILogger> loggers)
    {
        _loggers = loggers.Count > 0
            ? loggers
            : throw new ArgumentException("At least one logger must be provided.");
    }

    public void Log(string message, LogLv lv = LogLv.Info)
    {
        foreach (var logger in _loggers)
            logger.Log(message, lv);
    }
}