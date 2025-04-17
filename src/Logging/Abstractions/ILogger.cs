namespace Logging.Abstractions;

public interface ILogger
{
    void Log(string message, LogLv lv = LogLv.Info);
}