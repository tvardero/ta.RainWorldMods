using tvardero.DearDevTools.Components;

namespace tvardero.DearDevTools.Services;

public class MenuManager
{
    public IReadOnlyList<ImGuiDrawableBase> CurrentlyDrawn { get; } = new List<ImGuiDrawableBase>().AsReadOnly();

    public TMenu OpenMenu<TMenu>()
    where TMenu : ImGuiDrawableBase
    {
        throw new NotImplementedException();
    }

    public void CloseMenu<TMenu>(TMenu menu)
    where TMenu : ImGuiDrawableBase
    {
        throw new NotImplementedException();
    }

    public void HideMenu<TMenu>(TMenu menu)
    where TMenu : ImGuiDrawableBase
    {
        throw new NotImplementedException();
    }

    public void ShowMenu<TMenu>(TMenu menu, bool show = true)
    {
        throw new NotImplementedException();
    }
}