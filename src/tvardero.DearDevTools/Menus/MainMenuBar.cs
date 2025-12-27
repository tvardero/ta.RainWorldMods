using tvardero.DearDevTools.Components;
using tvardero.DearDevTools.Services;
using UnityEngine;
using UnityEngine.Diagnostics;

namespace tvardero.DearDevTools.Menus;

public class MainMenuBar : ImGuiDrawableBase
{
    private readonly MenuManager _menuManager;

    public MainMenuBar(MenuManager menuManager)
    {
        _menuManager = menuManager;
    }

    /// <inheritdoc />
    public override bool IsVisible => true;

    /// <inheritdoc />
    public override bool IsBlockingWMEvent => false;

    /// <inheritdoc />
    public override bool RequiresMainUiVisible => true;

    /// <inheritdoc />
    protected internal override void Draw()
    {
        ProcessShortcuts();

        if (ImGui.BeginMainMenuBar())
        {
            if (ImGui.BeginMenu("Menu"))
            {
                MenuBarMenu();
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Edit"))
            {
                MenuBarEdit();
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("View"))
            {
                MenuBarView();
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Navigate"))
            {
                MenuBarNavigate();
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Tools"))
            {
                MenuBarTools();
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Help"))
            {
                MenuBarHelp();
                ImGui.EndMenu();
            }

            ImGui.EndMainMenuBar();
        }
    }

    private static void EscapeTheEnd()
    {
        Utils.ForceCrash(ForcedCrashCategory.Abort);
    }

    private static void MenuBarView()
    {
        ImGui.MenuItem("RW Debug");
        ImGui.MenuItem("ImGui Debug");
    }

    private void MenuBarEdit()
    {
        ImGui.MenuItem("Undo", "Ctrl+Z");
        ImGui.MenuItem("Redo", "Ctrl+Y");

        ImGui.Separator();

        // TODO: history
        ImGui.MenuItem("Clear history");
    }

    private void MenuBarHelp()
    {
        if (ImGui.MenuItem("How to use Dear Dev Tools?", "F1")) _menuManager.EnsureShown<HelpMenu>();

        if (ImGui.MenuItem("Whats new?")) _menuManager.EnsureShown<WhatsNewMenu>();

        if (ImGui.MenuItem("Steam Workshop page")) Application.OpenURL("https://steamcommunity.com/sharedfiles/filedetails/?id=3417372413");

        if (ImGui.MenuItem("GitHub page")) Application.OpenURL("https://github.com/tvardero/tvardero.DearDevTools");

        if (ImGui.MenuItem("Report issue / suggest an idea")) Application.OpenURL("https://github.com/tvardero/tvardero.DearDevTools/issues");

        if (ImGui.MenuItem("Support development (ko-fi)")) Application.OpenURL("https://ko-fi.com/tvardero");

        ImGui.Separator();

        if (ImGui.MenuItem("Escape the end", "Esc + End")) EscapeTheEnd();
    }

    private void MenuBarMenu()
    {
        ImGui.MenuItem("Mod editor");
        ImGui.MenuItem("Region editor");
        ImGui.MenuItem("Dialog editor");
        ImGui.MenuItem("Map editor");
        ImGui.MenuItem("Palette editor");

        ImGui.Separator();

        ImGui.MenuItem("Settings");
    }

    private void MenuBarNavigate()
    {
        ImGui.MenuItem("Warp to region/room");
        ImGui.MenuItem("Warp back");

        ImGui.Separator();

        ImGui.MenuItem("Sleep screen");
        ImGui.MenuItem("Death screen");
        ImGui.MenuItem("Main menu");
    }

    private void MenuBarTools()
    {
        ImGui.MenuItem("Weather control");
        ImGui.MenuItem("Creatures control");
        ImGui.MenuItem("Kill all creatures except slugcat", "Ctrl+K");

        ImGui.Separator();

        ImGui.MenuItem("Room settings");
        ImGui.MenuItem("Palette editor");
        ImGui.MenuItem("Room effects");
        ImGui.MenuItem("Room objects");
        ImGui.MenuItem("Room sounds");
        ImGui.MenuItem("Room triggers");
    }

    private void ProcessShortcuts()
    {
        if (ImGui.Shortcut(ImGuiKey.F1)) _menuManager.EnsureShown<HelpMenu>();

        if (ImGui.Shortcut(ImGuiKey.Escape) && ImGui.Shortcut(ImGuiKey.End)) EscapeTheEnd();
    }
}