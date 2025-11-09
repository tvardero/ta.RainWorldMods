using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace ta.UIKit;

public sealed class ServiceLocator : IDisposable
{
    public ServiceProvider ServiceProvider { get; }

    public ILogger Logger { get; }

    public ILoggerFactory LoggerFactory { get; }

    public static ServiceLocator Instance { get; } = Create();

    private ServiceLocator(ServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        Logger = serviceProvider.GetRequiredService<ILogger<ServiceLocator>>();
        LoggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
    }

    private static ServiceLocator Create()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.ConfigureSerilogLogging("uiKitLog.txt", LogEventLevel.Verbose);
        serviceCollection.ConfigureUiKitCore();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var locator = new ServiceLocator(serviceProvider);

        locator.Logger.LogInformation("ServiceLocator created. Hello!");
        return locator;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Logger.LogInformation("Disposing ServiceLocator. Goodbye!");
        ServiceProvider.Dispose();
    }
}
