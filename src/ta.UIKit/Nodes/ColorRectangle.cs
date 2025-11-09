using System;
using System.Drawing;
using Microsoft.Extensions.Logging;

namespace ta.UIKit.Nodes;

public class ColorRectangle : AreaNode
{
    private FSprite _sprite = null!;

    /// <inheritdoc />
    public ColorRectangle(ILogger<ColorRectangle>? logger = null) : base(logger) { }

    public Color Color { get; set; }

    /// <inheritdoc />
    protected override void OnDispose()
    {
        _sprite.RemoveFromContainer(); // ensure removed
        _sprite = null!;
    }

    /// <param name="deltaTime"> </param>
    /// <inheritdoc />
    protected override void OnDraw(TimeSpan deltaTime)
    {
        base.OnDraw(deltaTime);

        _sprite.x = LocalPosition.X;
        _sprite.y = LocalPosition.Y;
        _sprite.scaleX = Size.Width;
        _sprite.scaleY = Size.Height;
        _sprite.color = Color.ToUnityColor();
        _sprite.isVisible = IsVisible;
    }

    /// <inheritdoc />
    protected override void OnInitialize()
    {
        base.OnInitialize();

        _sprite = new FSprite("pixel");
        Futile.stage.AddChild(_sprite);
    }
}
