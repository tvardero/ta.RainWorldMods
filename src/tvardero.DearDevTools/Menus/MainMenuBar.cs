using tvardero.DearDevTools.Components;

namespace tvardero.DearDevTools.Menus;

public class MainMenuBar : ImGuiDrawableBase
{
    /// <inheritdoc />
    public override bool IsVisible => true;

    /// <inheritdoc />
    public override bool IsBlockingWMEvent => false;

    /// <inheritdoc />
    public override bool RequiresMainUiShown => true;

    /// <inheritdoc />
    public override void Draw()
    {
        if (ImGui.BeginMainMenuBar())
        {
            if (ImGui.BeginMenu("Menu"))
            {
                if (ImGui.MenuItem("Test menu")) { TestMenu.Current.IsVisible = true; }

                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("View")) { ImGui.EndMenu(); }

            if (ImGui.BeginMenu("Edit")) { ImGui.EndMenu(); }

            if (ImGui.BeginMenu("Settings")) { ImGui.EndMenu(); }

            ImGui.EndMainMenuBar();
        }
    }
}