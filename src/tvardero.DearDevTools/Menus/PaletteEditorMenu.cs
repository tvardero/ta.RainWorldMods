using tvardero.DearDevTools.Components;
using tvardero.DearDevTools.Services;

namespace tvardero.DearDevTools.Menus;

public class PaletteEditorMenu : ImGuiWindowBase
{
    private readonly PaletteService _paletteService;

    // TODO: update name to Palette editor, see #1
    public PaletteEditorMenu(PaletteService paletteService) : base("Palette selector")
    {
        _paletteService = paletteService;
    }

    /// <inheritdoc />
    public override bool IsBlockingWMEvent => false;

    /// <inheritdoc />
    protected override void OnDrawWindowContent() { }
}