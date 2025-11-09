using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ta.UIKit.Logging;

namespace ta.UIKit;

public sealed class ServiceLocator : IDisposable
{
    private ServiceLocator(ServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        Logger = serviceProvider.GetRequiredService<ILogger<ServiceLocator>>();
        LoggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
    }

    private static ServiceLocator? _instance;

    public static ServiceLocator Instance
    {
        get
        {
            _instance ??= Create();
            return _instance;
        }
    }

    public ServiceProvider ServiceProvider { get; }

    public ILogger Logger { get; }

    public ILoggerFactory LoggerFactory { get; }

    /// <inheritdoc />
    public void Dispose()
    {
        Logger.LogInformation("Disposing ServiceLocator. Goodbye!");
        ServiceProvider.Dispose();
        _instance = null;
    }

    private static ServiceLocator Create()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.ConfigureUIKitCore();
        serviceCollection.AddLogging(l => l.AddBepInEx());

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        var locator = new ServiceLocator(serviceProvider);

        locator.Logger.LogInformation("ServiceLocator created. Hello!");
        return locator;
    }
}
