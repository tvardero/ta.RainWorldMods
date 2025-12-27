using RWIMGUI.API;
using tvardero.DearDevTools.Components;

namespace tvardero.DearDevTools.Services;

internal sealed class ModImGuiContext : IMGUIContext, IDisposable
{
    private readonly List<ImGuiDrawableBase> _renderList = [];
    private readonly IDearDevToolsPlugin _plugin;
    private ImGuiDrawableBase[]? _renderListSnapshot;
    private bool _disposed;

    public ModImGuiContext(IDearDevToolsPlugin plugin)
    {
        _plugin = plugin;
        RenderList = _renderList.AsReadOnly();
    }

    public IReadOnlyList<ImGuiDrawableBase> RenderList { get; }

    public bool IsActive => ImGUIAPI.CurrentContext == this;

    public void Activate()
    {
        if (!IsActive) ImGUIAPI.SwitchContext(this);
    }

    public void AddDrawable(ImGuiDrawableBase drawable)
    {
        if (_renderList.Contains(drawable)) return;

        _renderList.Add(drawable);
        _renderListSnapshot = null;
    }

    /// <inheritdoc />
    public override bool BlockWMEvent()
    {
        if (_disposed) return false;
        if (!_plugin.AreDearDevToolsActive) return false;

        bool isMainUiVisible = _plugin.IsMainUiVisible;
        return _renderList
            .Where(drawable => drawable is { IsDisposed: false, IsVisible: true })
            .Where(drawable => isMainUiVisible || !drawable.RequiresMainUiVisible)
            .Any(drawable => drawable.IsBlockingWMEvent);
    }

    public void Deactivate()
    {
        if (IsActive) ImGUIAPI.SwitchContext(null);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Deactivate();

        _disposed = true;
        _renderList.Clear();
        _renderListSnapshot = null;
    }

    public void RemoveDrawable(ImGuiDrawableBase drawable)
    {
        if (_renderList.Remove(drawable)) _renderListSnapshot = null;
    }

    /// <inheritdoc />
    public override void Render(ref IntPtr IDXGISwapChain, ref uint SyncInterval, ref uint Flags)
    {
        if (_disposed) return;
        if (!_plugin.AreDearDevToolsActive) return;

        SanitizeRenderList();

        bool isMainUiVisible = _plugin.IsMainUiVisible;
        IEnumerable<ImGuiDrawableBase> toDraw = GetRenderListSnapshot()
            .Where(drawable => drawable.IsVisible)
            .Where(drawable => isMainUiVisible || !drawable.RequiresMainUiVisible);

        foreach (ImGuiDrawableBase drawable in toDraw) { drawable.Draw(); }
    }

    public void SanitizeRenderList()
    {
        int countBefore = _renderList.Count;

        // remove null or disposed instances
        _renderList.RemoveAll(d => d is not { IsDisposed: false });

        if (countBefore != _renderList.Count) _renderListSnapshot = null;
    }

    private ImGuiDrawableBase[] GetRenderListSnapshot()
    {
        _renderListSnapshot ??= _renderList.ToArray();
        return _renderListSnapshot;
    }
}