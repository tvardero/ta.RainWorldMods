using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Exceptions;
using ta.UIKit.Nodes;

namespace ta.UIKit;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureSerilogLogging(
        this IServiceCollection services,
        string logFilePath,
        LogEventLevel minimumFileLogLevel = LogEventLevel.Information)
    {
        var serilog = new LoggerConfiguration();

        CultureInfo format = CultureInfo.InvariantCulture;
        serilog.WriteTo.File(logFilePath, formatProvider: format, restrictedToMinimumLevel: minimumFileLogLevel);
        serilog.WriteTo.Console(formatProvider: format, restrictedToMinimumLevel: LogEventLevel.Information);
        serilog.WriteTo.Debug(formatProvider: format);

        serilog.Enrich.WithExceptionDetails();
        serilog.Enrich.FromLogContext();

        var logger = serilog.CreateLogger();
        Log.Logger = logger;

        services.AddLogging(l => l.AddSerilog(logger, true));
        return services;
    }

    public static IServiceCollection ConfigureUiKitCore(this IServiceCollection services)
    {
        services.TryAddTransient(typeof(NodePool<>));
        services.TryAddSingleton(typeof(NodeFactory<>), typeof(ServiceProviderNodeFactory<>));
        services.AddSingleton<NodeFactory>();

        return services;
    }
}
