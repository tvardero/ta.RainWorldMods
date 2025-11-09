namespace ta.UIKit.InputEvents;

public record KeyInputEvent : InputEvent
{
    public char Key { get; private set; }

    public KeyState State { get; private set; }

    public bool IsDown => State == KeyState.IsDown;

    public bool IsUp => State == KeyState.IsUp;

    public bool IsEcho => State == KeyState.IsDownEcho;

    /// <inheritdoc />
    public override bool TryReset()
    {
        Key = (char)0;
        State = KeyState.IsDown;

        return base.TryReset();
    }

    internal void Set(char key, KeyState state)
    {
        Key = key;
        State = state;
    }

    public enum KeyState
    {
        IsDown,
        IsDownEcho,
        IsUp,
    }
}
