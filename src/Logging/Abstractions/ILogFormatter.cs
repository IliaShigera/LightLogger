namespace Logging.Abstractions;

public interface ILogFormatter
{
    string Format(LogEvent e);
}