namespace ta.ModMaker;

public interface IImGuiMenu
{
    bool IsEnabled { get; }
    
    void Disable();

    void Draw();

    void Enable();

    void ToggleEnabled();
}
