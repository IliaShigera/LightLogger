namespace Logging.Sinks;

public sealed class ConsoleLogger : ILogger, ILogFormatter
{
    public void Log(string message, LogLv lv = LogLv.Info)
    {
        var log = Format(new LogEvent(message, lv));
        Console.WriteLine(log);
    }

    public string Format(LogEvent e) =>
        $"{e.Timestamp:HH:mm:ss} [{e.Lv.ToString()[..3].ToUpper()}] {e.Message}";
}