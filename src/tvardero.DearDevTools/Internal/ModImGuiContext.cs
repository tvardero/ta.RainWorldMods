using RWIMGUI.API;
using tvardero.DearDevTools.Components;

namespace tvardero.DearDevTools.Internal;

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
        ImGUIAPI.SwitchContext(this);
    }

    /// <inheritdoc />
    public override bool BlockWMEvent()
    {
        return RenderList.All(d => !d.IsBlockingWMEvent);
    }

    public void Deactivate()
    {
        if (IsActive) ImGUIAPI.SwitchContext(null);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _disposed = true;
        RenderList.Clear();
    }

    /// <inheritdoc />
    public override void Render(ref IntPtr IDXGISwapChain, ref uint SyncInterval, ref uint Flags)
    {
        if (_disposed) return;

        foreach (ImGuiDrawableBase drawable in RenderList) { drawable.Draw(); }
    }
}