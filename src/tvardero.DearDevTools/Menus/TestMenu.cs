using tvardero.DearDevTools.Components;

namespace tvardero.DearDevTools.Menus;

internal sealed class TestMenu : SimpleImGuiWindowBase
{
    /// <inheritdoc />
    public TestMenu()
    {
        Current = this;
    }

    public static TestMenu Current { get; private set; } = null!;
    
    /// <inheritdoc />
    public override string Name => "Test menu";

    /// <inheritdoc />
    protected override void OnDrawWindowContent()
    {
        ImGui.Text("Hello from test menu");
    }
}