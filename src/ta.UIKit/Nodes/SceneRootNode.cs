using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using ta.UIKit.InputEvents;

namespace ta.UIKit.Nodes;

public sealed class SceneRootNode : Node
{
    private readonly InputEventPool _inputEventPool = new();
    private readonly Queue<InputEvent> _inputEventQueue = new();

    /// <inheritdoc />
    // ReSharper disable once ContextualLoggerProblem
    public SceneRootNode(ILogger<SceneRootNode>? logger = null) : base(logger) { }

    public FContainer FContainer { get; } = new();

    public void EnqueueInputEvent(object args)
    {
        InputEvent inputEvent = _inputEventPool.Get();
        _inputEventQueue.Enqueue(inputEvent);
    }

    public void LoopOnce(TimeSpan deltaTime)
    {
        var sw = Stopwatch.StartNew();

        while (_inputEventQueue.Count > 0)
        {
            InputEvent? inputEvent = _inputEventQueue.Dequeue();
            ProcessInputEvent(inputEvent);

            _inputEventPool.Return(inputEvent);
        }

        ProcessUpdate(deltaTime + sw.Elapsed);
        ProcessDraw(deltaTime + sw.Elapsed);
    }
}
