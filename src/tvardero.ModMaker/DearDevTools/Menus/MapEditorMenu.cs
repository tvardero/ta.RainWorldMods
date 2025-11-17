using System.Numerics;
using tvardero.ModMaker.Abstractions;

namespace tvardero.ModMaker.DearDevTools.Menus;

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
