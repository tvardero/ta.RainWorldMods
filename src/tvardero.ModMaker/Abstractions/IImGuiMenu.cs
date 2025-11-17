namespace tvardero.ModMaker.Abstractions;

public interface IImGuiMenu
{
    bool IsEnabled { get; }

    void Disable();

    void Draw();

    void Enable();

    void ToggleEnabled();
}
