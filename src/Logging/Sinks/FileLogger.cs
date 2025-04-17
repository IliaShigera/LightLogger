namespace Logging.Sinks;

public sealed class FileLogger : ILogger, ILogFormatter, IDisposable, IAsyncDisposable
{
    private readonly StreamWriter _writer;

    public FileLogger(string outputDirPath)
    {
        Directory.CreateDirectory(outputDirPath);
        var logFilePath = Path.Combine(outputDirPath, $"{DateTime.Today:yyyy-MM-dd}.json");

        _writer = new StreamWriter(logFilePath, append: true, Encoding.UTF8) { AutoFlush = true };
    }

    public void Log(string message, LogLv lv = LogLv.Info)
    {
        var log = Format(new LogEvent(message, lv));
        _writer.WriteLine(log);
    }


    public string Format(LogEvent e) =>
        $"{{\"ts\":\"{e.Timestamp:O}\",\"level\":\"{e.Lv}\",\"msg\":{EscapeJson(e.Message)}}}";

    private static string EscapeJson(string s) => JsonEncodedText.Encode(s).ToString();

    public void Dispose()
    {
        _writer.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _writer.DisposeAsync();
    }
}