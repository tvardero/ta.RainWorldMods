using Microsoft.Extensions.Logging;
using UnityEngine.Diagnostics;

namespace tvardero.DearDevTools.Services;

public class EndEscaperService
{
    private readonly ILogger _logger;

    public EndEscaperService(ILogger<EndEscaperService> logger)
    {
        _logger = logger;
    }

    public void EscapeTheEnd()
    {
        _logger.LogCritical("Escaping the end");
        Utils.ForceCrash(ForcedCrashCategory.Abort);
    }
}