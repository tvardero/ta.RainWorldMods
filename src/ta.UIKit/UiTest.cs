using System.Drawing;
using Microsoft.Extensions.Logging;
using ta.UIKit.InputEvents;
using ta.UIKit.Nodes;

namespace ta.UIKit;

public class UiTest
{
    private SceneRootNode? _scene;

    public void Register()
    {
        var nodeFactory = new NodeFactory();

        var scene = nodeFactory.Create<SceneRootNode>();

        var rect = nodeFactory.Create<TestRect>();
        rect.Color = Color.IndianRed;

        scene.AddChild(rect);

        _scene = scene;
    }

    public class TestRect : ColorRectangle
    {
        /// <inheritdoc />
        public TestRect(ILogger<TestRect>? logger = null) : base(logger) { }

        /// <inheritdoc />
        protected override void OnInputEvent(InputEvent inputEvent)
        {
            if (inputEvent is KeyInputEvent { IsDown: true, Key: 'h' })
            {
                Logger.LogInformation("Hello from TestRect");
                ToggleVisibile();
            }

            base.OnInputEvent(inputEvent);
        }
    }
}
