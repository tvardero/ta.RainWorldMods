using System.Collections.Concurrent;
using BepInEx.Logging;
using Microsoft.Extensions.Logging;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace tvardero.DearDevTools.Logging;

public sealed class BepInExLoggingProvider : ILoggerProvider
{
    private readonly ConcurrentDictionary<string, BepInExLogger> _loggers = new();
    private bool _disposed;
    private bool _disposing;

    public BepInExLoggingProvider(LogLevel minimumLogLevel = LogLevel.Information)
    {
        MinimumLogLevel = minimumLogLevel;
    }

    public LogLevel MinimumLogLevel { get; set; }

    /// <inheritdoc />
    public ILogger CreateLogger(string categoryName)
    {
        if (_disposed || _disposing) throw new ObjectDisposedException(nameof(BepInExLoggingProvider));

        return _loggers.GetOrAdd(categoryName,
            cn =>
            {
                string logSourceName = $"Dear Dev Tools ({cn})";
                ManualLogSource? mls = Logger.CreateLogSource(logSourceName);
                return new BepInExLogger(() => MinimumLogLevel, mls);
            });
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (_disposed || _disposing) return;

        _disposing = true;

        BepInExLogger[] loggers = _loggers.Values.ToArray();
        _loggers.Clear();

        foreach (BepInExLogger logger in loggers) { logger.Dispose(); }

        _disposed = true;
        _disposing = false;
    }
}