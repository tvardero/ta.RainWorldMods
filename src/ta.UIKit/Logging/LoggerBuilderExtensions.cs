using Microsoft.Extensions.Logging;

namespace ta.UIKit.Logging;

public static class LoggerBuilderExtensions
{
    public static void AddBepInEx(this ILoggingBuilder builder)
    {
        builder.AddProvider(new BepInExLoggerProvider());
    }
}
