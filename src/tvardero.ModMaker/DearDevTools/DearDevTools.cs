using tvardero.ModMaker.Abstractions;
using tvardero.ModMaker.DearDevTools.Menus;

namespace tvardero.ModMaker.DearDevTools;

public class DearDevTools
{
    private readonly Dictionary<string, IImGuiMenu> _menus = new();
    private bool _notificationsHistoryShortcutEnabled;

    public bool IsEnabled { get; set; }
    
    public void Draw()
    {
        if (!IsEnabled) return;

        ImGui.ShowDemoWindow();

        RegisterShortcuts();

        if (ImGui.BeginMainMenuBar())
        {
            DrawMainMenu_Menu();
            DrawMainMenu_View();
            DrawMainMenu_Edit();

            ImGui.EndMainMenuBar();
        }

        foreach (IImGuiMenu menu in _menus.Values) { menu.Draw(); }
    }

    private void RegisterShortcuts()
    {
        if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.M, ImGuiInputFlags.RouteAlways)) { ToggleMenu<MapEditorMenu>(); }

        if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.Comma, ImGuiInputFlags.RouteAlways)) { ToggleMenu<DearDevToolsSettingsMenu>(true); }
    }

    private void DrawMainMenu_View()
    {
        if (ImGui.BeginMenu("Tools"))
        {
            ImGui.SeparatorText("Quick actions");

            ImGui.MenuItem("Pause game");
            ImGui.MenuItem("Pause rain timer");
            ImGui.MenuItem("Pause creatures AI");
            ImGui.MenuItem("Reset rain timer");
            ImGui.MenuItem("End rain timer");
            ImGui.MenuItem("Kill all on-screen creatures");

            ImGui.Separator();

            ImGui.MenuItem("Console", "Ctrl+`");
            ImGui.MenuItem("Player tools");

            ImGui.SeparatorText("Room tools");

            ImGui.MenuItem("Palette editor");
            ImGui.MenuItem("Room settings");
            ImGui.MenuItem("Room objects");
            ImGui.MenuItem("Room sounds");

            ImGui.Separator();

            ImGui.MenuItem("Notifications history shortcut", null, ref _notificationsHistoryShortcutEnabled);
            ImGui.MenuItem("Notifications history");

            ImGui.EndMenu();
        }
    }

    private void DrawMainMenu_Menu()
    {
        if (ImGui.BeginMenu("Menus"))
        {
            if (ImGui.MenuItem("Open mod editor")) { ToggleMenu<ModEditorMenu>(true); }

            if (ImGui.MenuItem("Open region editor")) { ToggleMenu<RegionEditorMenu>(true); }

            if (ImGui.MenuItem("Open map editor", "Ctrl+M")) { ToggleMenu<MapEditorMenu>(true); }

            if (ImGui.MenuItem("Open dialog editor")) { ToggleMenu<DialogEditorMenu>(true); }

            ImGui.Separator();

            if (ImGui.MenuItem("Dev tools settings", "Ctrl+,")) { ToggleMenu<DearDevToolsSettingsMenu>(true); }

            ImGui.Separator();

            if (ImGui.MenuItem("Close")) { IsEnabled = false; }

            ImGui.EndMenu();
        }
    }

    private void DrawMainMenu_Edit()
    {
        if (ImGui.BeginMenu("Edit"))
        {
            if (ImGui.MenuItem("Undo", "Ctrl+Z")) { }

            if (ImGui.MenuItem("Redo", "Ctrl+Y")) { }

            ImGui.Separator();

            if (ImGui.MenuItem("History item 1")) { }

            if (ImGui.MenuItem("History item 2")) { }

            if (ImGui.MenuItem("History item 3")) { }

            ImGui.EndMenu();
        }
    }

    private bool GetMenuState<TMenu>()
    where TMenu : IImGuiMenu
    {
        string typeName = typeof(TMenu).Name;
        return _menus.TryGetValue(typeName, out IImGuiMenu? menu) && menu.IsEnabled;
    }

    private void ToggleMenu<TMenu>(bool? enabled = null)
    where TMenu : IImGuiMenu, new()
    {
        string typeName = typeof(TMenu).Name;

        if (!_menus.TryGetValue(typeName, out IImGuiMenu? menu))
        {
            menu = new TMenu();
            _menus.Add(typeName, menu);
        }

        switch (enabled)
        {
            case true: menu.Enable(); break;
            case false: menu.Disable(); break;
            case null: menu.ToggleEnabled(); break;
        }
    }
}
