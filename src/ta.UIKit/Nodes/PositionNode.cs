using Microsoft.Extensions.Logging;
using UnityEngine;

namespace ta.UIKit.Nodes;

public class PositionNode : Node
{
    /// <inheritdoc />
    public PositionNode(ILogger<PositionNode>? logger = null) : base(logger) { }

    public Vector2 LocalPosition { get; set; }

    public Vector2 GlobalPosition => Parent is PositionNode positionParent ? positionParent.LocalPosition + LocalPosition : LocalPosition;
}
