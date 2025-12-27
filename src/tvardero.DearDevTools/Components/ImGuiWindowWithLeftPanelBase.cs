using System.Numerics;

namespace tvardero.DearDevTools.Components;

public abstract class ImGuiWindowWithLeftPanelBase : ImGuiWindowBase
{
    /// <inheritdoc />
    protected ImGuiWindowWithLeftPanelBase(
        string title,
        ImGuiWindowFlags windowFlags = ImGuiWindowFlags.None,
        Vector2? initialSize = null,
        bool disposeOnClose = false,
        bool allowMultipleInstances = false)
        : base(title, windowFlags, initialSize, disposeOnClose, allowMultipleInstances) { }

    public bool IsLeftPanelCollapsed { get; set; }

    protected abstract void OnDrawLeftPanel();

    protected abstract void OnDrawMiddleContent();

    /// <inheritdoc />
    protected sealed override void OnDrawWindowContent()
    {
        ImGui.BeginMenuBar();

        string title = IsLeftPanelCollapsed ? "Show left panel###Collapse" : "Hide left panel###Collapse";
        if (ImGui.BeginMenu(title)) IsLeftPanelCollapsed = !IsLeftPanelCollapsed;

        ImGui.EndMenuBar();

        if (!IsLeftPanelCollapsed)
        {
            ImGui.BeginChild("Left pane", new Vector2(150, 0), ImGuiChildFlags.Borders | ImGuiChildFlags.ResizeX);
            OnDrawLeftPanel();
            ImGui.EndChild();

            ImGui.SameLine();
        }

        OnDrawMiddleContent();
    }
}