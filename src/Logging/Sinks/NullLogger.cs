namespace Logging.Sinks;

public sealed class NullLogger : ILogger
{
    public static readonly NullLogger Instance = new();
    
    private NullLogger()
    {
    }
    
    public void Log(string message, LogLv lv = LogLv.Info)
    {
    }
}