using System;
using System.Drawing;
using BepInEx;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ta.UIKit.Nodes;

namespace ta.UIKit;

[BepInPlugin("ta.UIKit", "ta.UIKit", "0.0.1")]
public class UiKitPlugin : BaseUnityPlugin
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

        try { Test(); }
        catch (Exception e) { Logger.LogError($"Failed to test ta.UIKit: {e.Message} \n{e}"); }

        _initialized = true;

        On.RainWorld.OnModsInit += (orig, self) =>
        {
            orig(self);
            Test();
        };
    }

    private static void Test()
    {
        var fsprite = new FSprite("pixel");
        fsprite.scaleX = 200;
        fsprite.scaleY = 200;
        fsprite.x = 200;
        fsprite.y = 200;
        fsprite.color = UnityEngine.Color.red;
        fsprite.isVisible = true;
        Futile.stage.AddChild(fsprite);
        
        var serviceProvider = ServiceLocator.Instance.ServiceProvider;
        
        var nodeFactory = serviceProvider.GetRequiredService<NodeFactory>();
        var sceneManager = serviceProvider.GetRequiredService<SceneManager>();

        var rect = nodeFactory.Create<ColorRectangle>();
        rect.Color = Color.IndianRed;
        rect.Size = new Size(100, 100);
        rect.LocalPosition = new Point(100, 100);
        rect.ProcessDraw(TimeSpan.Zero);

        var scene = nodeFactory.Create<SceneRootNode>();
        scene.AddChild(rect);

        sceneManager.SwitchScene(scene);
    }
}
