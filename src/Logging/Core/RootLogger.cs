namespace Logging.Core;

public sealed class RootLogger : ILogger, IDisposable
{
    private readonly ILogger _inner;
    private readonly List<IDisposable>? _disposables;

    public RootLogger(ILogger inner, IReadOnlyList<ILogger> components)
    {
        _inner = inner;

        foreach (var l in components)
            if (l is IDisposable d)
            {
                _disposables ??= [];
                _disposables.Add(d);
            }
    }

    public void Log(string message, LogLv lv = LogLv.Info) =>
        _inner.Log(message, lv);


    public void Dispose()
    {
        if (_disposables is null)
            return;

        foreach (var d in _disposables)
            d.Dispose();
    }
}