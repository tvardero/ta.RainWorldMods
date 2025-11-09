using Microsoft.Extensions.ObjectPool;

namespace ta.UIKit.InputEvents;

public class InputEventPool
{
    private readonly ObjectPool<InputEvent> _pool = ObjectPool.Create<InputEvent>();

    public InputEvent Get()
    {
        return _pool.Get();
    }

    public void Return(InputEvent obj)
    {
        _pool.Return(obj);
    }
}
