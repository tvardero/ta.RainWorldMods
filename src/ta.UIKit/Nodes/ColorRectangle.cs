using System;
using System.Drawing;
using Microsoft.Extensions.Logging;

namespace ta.UIKit.Nodes;

public class ColorRectangle : AreaNode
{
    private FSprite _sprite = null!;

    /// <inheritdoc />
    public ColorRectangle(ILogger<ColorRectangle>? logger = null) : base(logger) { }

    public Color Color { get; set; } = Color.DarkGray;

    /// <inheritdoc />
    protected override void OnAttachedToScene(SceneRootNode scene)
    {
        scene.FContainer.AddChild(_sprite);

        base.OnAttachedToScene(scene);
    }

    /// <inheritdoc />
    protected override void OnDetachedFromScene(SceneRootNode scene)
    {
        scene.FContainer.RemoveChild(_sprite);

        base.OnDetachedFromScene(scene);
    }

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
        _sprite.x = LocalPosition.X;
        _sprite.y = LocalPosition.Y;
        _sprite.scaleX = Size.Width;
        _sprite.scaleY = Size.Height;
        _sprite.color = Color.ToUnityColor();
        _sprite.isVisible = IsVisible;

        base.OnDraw(deltaTime);
    }

    /// <inheritdoc />
    protected override void OnInitialize()
    {
        base.OnInitialize();

        _sprite = new FSprite("pixel")
        {
            anchorX = 0,
            anchorY = 0,
            x = LocalPosition.X,
            y = LocalPosition.Y,
            scaleX = Size.Width,
            scaleY = Size.Height,
            color = Color.ToUnityColor(),
            isVisible = IsVisible,
        };
    }
}
