namespace tvardero.DearDevTools.Components;

public abstract class ImGuiDrawableBase
{
    public virtual bool IsVisible { get; set; } = true;

    public virtual bool RequiresMainUiShown { get; set; } = true;

    public virtual bool IsBlockingWMEvent { get; set; } = true;

    public abstract void Draw();
}