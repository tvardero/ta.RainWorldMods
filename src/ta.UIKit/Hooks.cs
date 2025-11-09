using System;
using System.Drawing;
using BepInEx;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ta.UIKit.Nodes;

namespace ta.UIKit;

[BepInPlugin("ta.UIKit", "ta.UIKit", "0.0.1")]
public class Hooks : BaseUnityPlugin
{
    private bool _initialized;
    private ServiceLocator? _serviceLocator;

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

    [UsedImplicitly]
    public void OnEnable()
    {
        if (_initialized) return;

        Logger.LogInfo("ta.UIKit initializing");

        try
        {
            _serviceLocator = ServiceLocator.Instance;
            Logger.LogInfo("ta.UIKit initialized");
        }
        catch (Exception e)
        {
            Logger.LogError($"Failed to initialize ta.UIKit: {e.Message} \n{e}");
            throw;
        }

        try { Test(_serviceLocator.ServiceProvider); }
        catch (Exception e)
        {
            _serviceLocator.Logger.LogError(e, "Failed to test ta.UIKit");
        }

        _initialized = true;
    }

    private void Test(IServiceProvider serviceProvider)
    {
        var nodeFactory = serviceProvider.GetRequiredService<NodeFactory>();
        var sceneManager = serviceProvider.GetRequiredService<SceneManager>();

        var rect = new ColorRectangle();
        rect.Color = Color.IndianRed;

        var scene = nodeFactory.Create<SceneRootNode>();
        scene.AddChild(rect);

        sceneManager.SwitchScene(scene);
    }
}
