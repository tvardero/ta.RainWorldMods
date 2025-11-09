using System;
using BepInEx;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ta.UIKit;

[BepInPlugin("ta.UIKit", "ta.UIKit", "0.0.1")]
public class Hooks : BaseUnityPlugin
{
    private bool _initialized;
    private ServiceLocator? _serviceLocator;

    [UsedImplicitly]
    public void OnEnable()
    {
        Initialize();
    }

    [UsedImplicitly]
    public void OnDisable()
    {
        Logger.LogInfo("ta.UIKit de-initializing");

        try { _serviceLocator?.Dispose(); }
        catch (Exception e)
        {
            Logger.LogError($"Failed to dispose service locator: {e.Message}");
            throw;
        }

        Logger.LogInfo("ta.UIKit de-initialized");
        _initialized = false;
    }

    private void Initialize()
    {
        if (_initialized) return;

        Logger.LogInfo("ta.UIKit initializing");

        try
        {
            _serviceLocator = ServiceLocator.Instance;
            _serviceLocator.Logger.LogInformation("Service locator initialized at {Timestamp}", DateTimeOffset.Now);

            Logger.LogInfo("ta.UIKit initialized");
        }
        catch (Exception e)
        {
            Logger.LogError($"Failed to initialize ta.UIKit: {e.Message}");
            throw;
        }

        _initialized = true;
    }
}
