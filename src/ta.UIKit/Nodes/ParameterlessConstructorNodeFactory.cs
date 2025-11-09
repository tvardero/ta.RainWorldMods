using System;

namespace ta.UIKit.Nodes;

public class ParameterlessConstructorNodeFactory<TNode> : NodeFactory<TNode>
where TNode : Node, new()
{
    /// <inheritdoc />
    public override TNode Create()
    {
        return Activator.CreateInstance<TNode>();
    }
}
