using tvardero.DearDevTools.Abstractions;

namespace tvardero.DearDevTools.Menus;

public class MapEditorMenu : ImGuiMenuBase
{
    /// <inheritdoc />
    public override string MenuName => "Map Editor";

    /// <inheritdoc />
    protected override void OnDraw()
    {
        ImGuiViewportPtr viewport = ImGui.GetMainViewport();

        ImGui.SetNextWindowPos(viewport.WorkPos);
        ImGui.SetNextWindowSize(viewport.WorkSize);

        ImGui.Begin(MenuName, ref _isEnabled, ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings);

        ImGui.End();
    }
}
