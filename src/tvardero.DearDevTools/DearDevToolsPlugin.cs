using BepInEx;
using JetBrains.Annotations;
using RWIMGUI.API;

namespace tvardero.DearDevTools;

[BepInPlugin("tvardero.DearDevTools", "Dear Dev Tools", "0.0.4")]
[BepInDependency("rwimgui")]
public sealed class DearDevToolsPlugin : BaseUnityPlugin
{
    private static DearDevToolsPlugin? _instance;
    private DearDevTools _dearDevTools = null!;
    private DearDevToolsImGuiContext _imguiContext = null!;

    public static bool IsInitialized => _instance != null;

    public static DearDevToolsPlugin Instance => _instance ?? throw new InvalidOperationException("Plugin not initialized");

    [UsedImplicitly]
    public void Awake()
    {
        if (IsInitialized) return;

        Logger.LogInfo("Initializing tvardero.DearDevTools");

        On.RainWorld.OnModsInit += OnModsInit;

        _instance = this;
        Logger.LogInfo("Initialized tvardero.DearDevTools");
    }

    private void OnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
        orig(self);

        _dearDevTools = new DearDevTools();
        _imguiContext = new DearDevToolsImGuiContext(_dearDevTools);
    }

    [UsedImplicitly]
    private void OnDisable()
    {
        if (!IsInitialized) return;

        Logger.LogInfo("Deinitializing tvardero.DearDevTools");

        _instance = null;

        if (ImGUIAPI.CurrentContext == _imguiContext) ImGUIAPI.SwitchContext(null);

        _imguiContext = null!;
        _dearDevTools = null!;

        On.RainWorld.OnModsInit -= OnModsInit;

        Logger.LogInfo("Deinitialized tvardero.DearDevTools");
    }
}
