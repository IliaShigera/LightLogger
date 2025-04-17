namespace Logging.Factory;

public sealed class LoggerFactory : ILoggerFactory
{
    private readonly LoggerConfig _config;

    public LoggerFactory(LoggerConfig config)
    {
        _config = config;
    }

    public ILogger CreateLogger()
    {
        var levelParsed = Enum.TryParse<LogLv>(_config.MinLv, ignoreCase: true, out var minLv)
            ? minLv
            : LogLv.Info;

        var loggers = new List<ILogger>();
        var disposables = new List<ILogger>();

        if (_config.WriteConsole)
            loggers.Add(new ConsoleLogger());

        if (_config.WriteFile)
        {
            var outputDir = !string.IsNullOrWhiteSpace(_config.OutputDirectoryPath)
                ? _config.OutputDirectoryPath
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

            var fileLogger = new FileLogger(outputDir);
            loggers.Add(fileLogger);
            disposables.Add(fileLogger);
        }

        var logger = loggers.Count switch
        {
            0 => NullLogger.Instance,
            1 => loggers[0],
            _ => new MultiLogger(loggers)
        };

        var filteredLogger = new FilteredLoggerWrap(logger, () => levelParsed);
        var root = new RootLogger(filteredLogger, disposables);
        return root;
    }
}