namespace Logging.Core;

public sealed class FilteredLoggerWrap : ILogger
{
    private readonly ILogger _inner;
    private readonly Func<LogLv> _filter;

    public FilteredLoggerWrap(ILogger inner, Func<LogLv> filter)
    {
        _inner = inner;
        _filter = filter;
    }

    public void Log(string message, LogLv lv = LogLv.Info)
    {
        if (lv >= _filter())
            _inner.Log(message, lv);
    }
}