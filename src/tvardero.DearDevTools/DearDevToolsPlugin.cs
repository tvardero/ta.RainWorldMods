using BepInEx;
using JetBrains.Annotations;
using RWIMGUI.API;
using tvardero.DearDevTools.ImMenus;

namespace tvardero.DearDevTools;

[BepInPlugin(ID, NAME, VERSION)]
[BepInDependency(IMGUI_ID)]
public sealed class DearDevToolsPlugin : BaseUnityPlugin
{
    public const string ID = "tvardero.DearDevTools";
    public const string NAME = "Dear Dev Tools";
    public const string VERSION = "0.0.2";
    public const string IMGUI_ID = "rwimgui";

    private bool _initialized;

    [UsedImplicitly]
    public void Awake()
    {
        if (_initialized) return;

        Logger.LogInfo($"Initializing {ID}");

        On.RainWorld.OnModsInit += (orig, self) =>
        {
            orig(self);
            unsafe { ImGUIAPI.AddMenuCallback(&MainImMenu.MenuCallback); }
        };

        _initialized = true;
        Logger.LogInfo($"Initialized {ID}");
    }
}
