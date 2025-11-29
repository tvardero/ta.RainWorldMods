using tvardero.DearDevTools.Components;

namespace tvardero.DearDevTools.Menus;

internal class TestMenu : SimpleImGuiWindowBase
{
    public TestMenu(DearDevToolsPlugin plugin)
    {
        plugin.OnMainUiVisibleChange += visible => { IsVisible = visible; };
    }

    /// <inheritdoc />
    public override bool IsBlockingWMEvent => true;

    /// <inheritdoc />
    public override string Name => "Test menu";

    /// <inheritdoc />
    protected override void OnDrawWindowContent()
    {
        ImGui.Text("Test menu. Hello World!");
    }
}