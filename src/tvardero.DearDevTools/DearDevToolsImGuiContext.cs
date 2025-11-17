using RWIMGUI.API;

namespace tvardero.DearDevTools;

public class DearDevToolsImGuiContext : IMGUIContext
{
    private readonly DearDevTools _dearDevTools;

    public DearDevToolsImGuiContext(DearDevTools dearDevTools)
    {
        _dearDevTools = dearDevTools;
    }

    /// <inheritdoc />
    public override bool BlockWMEvent()
    {
        return _dearDevTools.ShouldBlockInputs;
    }

    /// <inheritdoc />
    public override void Render(ref IntPtr idxgiSwapChain, ref uint syncInterval, ref uint flags)
    {
        _dearDevTools.Draw();
    }
}
