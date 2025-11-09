using System.Drawing;
using Microsoft.Extensions.Logging;

namespace ta.UIKit.Nodes;

public class PositionNode : Node
{
    /// <inheritdoc />
    public PositionNode(ILogger<PositionNode>? logger = null) : base(logger) { }

    public Point LocalPosition { get; set; }

    public Point GlobalPosition => Parent is PositionNode positionParent ? positionParent.LocalPosition + new Size(LocalPosition) : LocalPosition;
}
