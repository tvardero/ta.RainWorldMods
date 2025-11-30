using System.Numerics;
using tvardero.DearDevTools.Components;

namespace tvardero.DearDevTools.Menus;

public class DearDevToolsEnabledTooltip : ImGuiDrawableBase
{
    /// <inheritdoc />
    public override bool IsVisible => true;

    /// <inheritdoc />
    public override bool RequiresMainUiShown => false;

    /// <inheritdoc />
    public override bool IsBlockingWMEvent => false;

    /// <inheritdoc />
    public override void Draw()
    {
        ImGuiIOPtr io = ImGui.GetIO();
        const float _PADDING = 10f;
        var windowSize = new Vector2(250, 50);

        ImGui.SetNextWindowPos(new Vector2(io.DisplaySize.X - windowSize.X - _PADDING, io.DisplaySize.Y - windowSize.Y - _PADDING),
            ImGuiCond.Always);

        ImGui.SetNextWindowSize(windowSize, ImGuiCond.Always);

        ImGui.Begin("##DearDevToolsEnabled",
            ImGuiWindowFlags.NoTitleBar |
            ImGuiWindowFlags.NoResize |
            ImGuiWindowFlags.NoMove |
            ImGuiWindowFlags.NoCollapse);

        ImGui.Text("Dear Dev Tools are enabled");

        ImGui.End();
    }
}