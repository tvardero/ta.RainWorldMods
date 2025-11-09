using System;
using BepInEx.Logging;
using Microsoft.Extensions.Logging;

namespace ta.UIKit.Logging;

public class BepInExLoggerProvider : ILoggerProvider
{
    /// <inheritdoc />
    public ILogger CreateLogger(string categoryName)
    {
        ManualLogSource? logSource = Logger.CreateLogSource(categoryName);
        return new BepInExLogger(logSource);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
