namespace tvardero.DearDevTools.Components;

public abstract class ImGuiDrawableBase
{
    public virtual bool IsVisible { get; set; }

    public abstract bool IsBlockingWMEvent { get; }

    internal void Draw()
    {
        if (!IsVisible) return;

        OnDraw();
    }

    protected abstract void OnDraw();
}