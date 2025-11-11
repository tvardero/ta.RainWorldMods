namespace ta.UIKit.Nodes;

public class ParameterlessConstructorNodeFactory<TNode> : NodeFactory<TNode>
where TNode : Node, new()
{
    /// <inheritdoc />
    public override TNode Create()
    {
        var node = Activator.CreateInstance<TNode>();
        node.Initialize();

        return node;
    }
}
