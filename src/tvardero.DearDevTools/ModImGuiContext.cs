using RWIMGUI.API;
using tvardero.DearDevTools.Components;

namespace tvardero.DearDevTools;

internal sealed class ModImGuiContext : IMGUIContext, IDisposable
{
    private readonly DearDevToolsPlugin _plugin;
    private bool _disposed;

    public ModImGuiContext(DearDevToolsPlugin plugin)
    {
        _plugin = plugin;
    }

    public List<ImGuiDrawableBase> RenderList { get; } = [];

    public bool IsActive => ImGUIAPI.CurrentContext == this;

    public void Activate()
    {
        if (!IsActive) ImGUIAPI.SwitchContext(this);
    }

    /// <inheritdoc />
    public override bool BlockWMEvent()
    {
        if (_disposed) return false;
        if (!_plugin.AreDearDevToolsActive) return false;

        return RenderList
            .Where(drawable => drawable.IsVisible)
            .Where(drawable => !drawable.RequiresMainUiShown || _plugin.IsMainUiVisible)
            .Any(drawable => drawable.IsBlockingWMEvent);
    }

    public void Deactivate()
    {
        if (IsActive) ImGUIAPI.SwitchContext(null);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (IsActive) Deactivate();

        _disposed = true;
        RenderList.Clear();
    }

    /// <inheritdoc />
    public override void Render(ref IntPtr IDXGISwapChain, ref uint SyncInterval, ref uint Flags)
    {
        if (_disposed) return;
        if (!_plugin.AreDearDevToolsActive) return;

        IEnumerable<ImGuiDrawableBase> toDraw = RenderList
            .Where(drawable => drawable.IsVisible)
            .Where(drawable => !drawable.RequiresMainUiShown || _plugin.IsMainUiVisible);

        foreach (ImGuiDrawableBase drawable in toDraw) { drawable.Draw(); }
    }
}