using System.Drawing;
using Microsoft.Extensions.Logging;

namespace ta.UIKit.Nodes;

public class AreaNode : PositionNode
{
    /// <inheritdoc />
    public AreaNode(ILogger<AreaNode>? logger = null) : base(logger) { }

    public Size Size { get; set; }

    public Rectangle Area
    {
        get => new(LocalPosition, Size);

        set
        {
            LocalPosition = value.Location;
            Size = value.Size;
        }
    }
}
