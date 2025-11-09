using ta.UIKit.Nodes;

namespace ta.UIKit;

public class SceneManager
{
    public SceneRootNode? CurrentScene { get; private set; }

    public void SwitchScene(SceneRootNode? scene)
    {
        CurrentScene?.PropagateSceneExit();
        CurrentScene = scene;
        CurrentScene?.PropagateSceneEnter();
    }
}
