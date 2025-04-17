namespace Logging.Abstractions;

public interface ILoggerFactory
{
    ILogger CreateLogger();
}