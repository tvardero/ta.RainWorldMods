namespace tvardero.ModMaker.Abstractions;

public abstract class ImGuiMenuBase : IImGuiMenu
{
    protected bool _isEnabled;

    public bool IsEnabled => _isEnabled;

    public abstract string MenuName { get; }

    /// <inheritdoc />
    public void Disable()
    {
        if (!_isEnabled) return;

        _isEnabled = false;
        OnDisable();
    }

    /// <inheritdoc />
    public void Draw()
    {
        if (!_isEnabled) return;

        OnDraw();
    }

    /// <inheritdoc />
    public void Enable()
    {
        if (_isEnabled) return;

        _isEnabled = true;
        OnEnable();
    }

    /// <inheritdoc />
    public void ToggleEnabled()
    {
        _isEnabled = !_isEnabled;

        if (_isEnabled) { OnEnable(); }
        else OnDisable();
    }

    protected virtual void OnDisable() { }

    protected abstract void OnDraw();

    protected virtual void OnEnable() { }
}