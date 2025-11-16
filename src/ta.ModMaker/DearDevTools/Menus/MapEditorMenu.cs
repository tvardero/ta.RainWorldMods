using System.Numerics;

namespace ta.ModMaker.DearDevTools.Menus;

public class MapEditorMenu : ImGuiMenuBase
{
    /// <inheritdoc />
    public override string MenuName => "Map Editor";

    /// <inheritdoc />
    protected override void OnDraw()
    {
        var viewport = ImGui.GetMainViewport();

        ImGui.SetNextWindowPos(viewport.WorkPos);
        ImGui.SetNextWindowSize(viewport.WorkSize);

        ImGui.Begin("Map Editor", ref _isEnabled, ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings);

        ImGui.End();
    }
}
