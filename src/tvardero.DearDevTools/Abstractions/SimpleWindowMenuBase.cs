using System.Numerics;

namespace tvardero.DearDevTools.Abstractions;

public abstract class SimpleWindowMenuBase : ImGuiMenuBase
{
    /// <inheritdoc />
    protected override void OnDraw()
    {
        ImGui.SetNextWindowSize(new Vector2(600, 400), ImGuiCond.FirstUseEver);
        ImGui.Begin(MenuName, ref _isEnabled);

        OnDrawContent();

        ImGui.End();
    }

    protected abstract void OnDrawContent();
}
