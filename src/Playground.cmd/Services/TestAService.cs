namespace Playground.cmd.Services;

public class TestAService : IService
{
    private readonly ILogger _logger;

    public TestAService(ILogger logger)
    {
        _logger = logger;
    }

    public void Foo()
    {
        _logger.LogInfo("Hello from TestAService");
        _logger.LogWarning("warning from TestAService");
        _logger.LogError("error from TestAService");
    }
}