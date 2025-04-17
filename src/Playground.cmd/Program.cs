using Logging.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Playground.cmd.Services;

const string AppsettingsFileName = "appsettings.json";


var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile(AppsettingsFileName, optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration
            .GetRequiredSection("Logger")
            .Get<LoggerConfig>();

        services.AddSingleton(config);
        services.AddScoped<ILoggerFactory, LoggerFactory>();

        services.AddSingleton(sp =>
        {
            using var scope = sp.CreateScope();
            var factory = sp.GetRequiredService<ILoggerFactory>();
            return factory.CreateLogger();
        });

        services.AddScoped<IService, TestAService>();
    }).Build();


var service = host.Services.GetRequiredService<IService>();

while (true)
{
    service.Foo();
    var key = Console.ReadLine();

    if (key == "q")
    {
        break;
    }
}


await host.StopAsync();