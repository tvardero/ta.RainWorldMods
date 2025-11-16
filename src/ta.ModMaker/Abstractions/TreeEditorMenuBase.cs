using System.Numerics;

namespace ta.ModMaker;

public abstract class TreeEditorMenuBase : SimpleWindowMenuBase
{
    /// <inheritdoc />
    protected override void OnDrawContent()
    {
        // left side
        ImGui.BeginChild("##left", new Vector2(250, 0));

        OnDrawTree();

        ImGui.EndChild();

        // right side
    }

    protected abstract void OnDrawTree();

    protected abstract void OnDrawSelected();
}