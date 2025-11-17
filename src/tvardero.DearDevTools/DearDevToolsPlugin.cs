using BepInEx;
using JetBrains.Annotations;
using RWIMGUI.API;

namespace tvardero.DearDevTools;

[BepInPlugin(ID, NAME, VERSION)]
[BepInDependency(IMGUI_ID)]
public sealed class DearDevToolsPlugin : BaseUnityPlugin
{
    public const string ID = "tvardero.DearDevTools";
    public const string NAME = "Dear Dev Tools";
    public const string VERSION = "0.0.2";
    public const string IMGUI_ID = "rwimgui";

    private static DearDevToolsPlugin? _instance;
    private DearDevTools _dearDevTools = null!;
    private DearDevToolsImGuiContext _imguiContext = null!;
    private bool _initialized;

    public static DearDevToolsPlugin Instance => _instance ?? throw new InvalidOperationException("Plugin not initialized");

    [UsedImplicitly]
    public void Awake()
    {
        if (_initialized) return;

        Logger.LogInfo($"Initializing {ID}");

        On.RainWorld.OnModsInit += (orig, self) =>
        {
            orig(self);

            _dearDevTools = new DearDevTools();
            _imguiContext = new DearDevToolsImGuiContext(_dearDevTools);

            unsafe { ImGUIAPI.AddAlwaysCallback(&OnAlways); }
        };

        _initialized = true;
        _instance = this;
        Logger.LogInfo($"Initialized {ID}");
    }

    private static void OnAlways(ref nint idxgiSwapChain, ref uint syncInterval, ref uint flags)
    {
        // todo move key to input config
        if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.H, ImGuiInputFlags.RouteAlways))
        {
            DearDevTools devTools = Instance._dearDevTools;
            devTools.IsEnabled = !devTools.IsEnabled;

            if (devTools.IsEnabled)
            {
                DearDevToolsImGuiContext imguiContext = Instance._imguiContext;
                ImGUIAPI.SwitchContext(imguiContext);
            }
            else ImGUIAPI.SwitchContext(null);
        }
    }
}
