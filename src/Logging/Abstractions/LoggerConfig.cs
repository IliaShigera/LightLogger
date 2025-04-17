namespace Logging.Abstractions;

public sealed class LoggerConfig
{
    public bool WriteConsole { get; set; } = true;

    public bool WriteFile { get; set; } = false;

    public string OutputDirectoryPath { get; set; } = "logs";

    public string MinLv { get; set; } = "Info";
}