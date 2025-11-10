using System.Linq;
using Microsoft.Extensions.Logging;
using UnityEngine;

namespace ta.UIKit.Nodes;

public class AreaNode : PositionNode
{
    /// <inheritdoc />
    public AreaNode(ILogger<AreaNode>? logger = null) : base(logger) { }

    public Vector2 Size { get; set; }

    public float Top => LocalPosition.y + Size.y;

    public float Left => LocalPosition.x;

    public float Bottom => LocalPosition.y;

    public float Right => LocalPosition.x + Size.x;

    public float Width => Size.x;

    public float Height => Size.y;

    public float LeftWithChildren =>
        Children
            .OfType<PositionNode>()
            .Select(p => p.LocalPosition.x)
            .Append(Left)
            .Min();

    public float BottomWithChildren =>
        Children
            .OfType<PositionNode>()
            .Select(p => p.LocalPosition.y)
            .Append(Bottom)
            .Min();

    public float TopWithChildren =>
        Children
            .OfType<PositionNode>()
            .Select(p => p is AreaNode areaNode ? areaNode.TopWithChildren : p.LocalPosition.y)
            .Append(Top)
            .Max();

    public float RightWithChildren =>
        Children.OfType<PositionNode>()
            .Select(p => p is AreaNode areaNode ? areaNode.RightWithChildren : p.LocalPosition.x)
            .Append(Right)
            .Max();

    public Vector2 SizeWithChildren => new(RightWithChildren - LeftWithChildren, TopWithChildren - BottomWithChildren);

    public Vector2 PositionWithChildren => new(LeftWithChildren, BottomWithChildren);

    public Vector2 Center => (LocalPosition + Size) / 2f;
}
