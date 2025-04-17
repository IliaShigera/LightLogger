namespace Logging.Abstractions;

public readonly struct LogEvent
{
    public LogEvent(string message, LogLv lv)
    {
        Timestamp = DateTime.Now;
        Message = message;
        Lv = lv;
    }

    public DateTime Timestamp { get; }
    public string Message { get; }
    public LogLv Lv { get; }
}