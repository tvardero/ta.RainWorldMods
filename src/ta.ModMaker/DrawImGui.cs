using System.Numerics;
using ImGuiNET;

namespace ta.ModMaker;

public class DrawImGui
{
    private bool _isWindowOpen;
    private bool _checkbox;
    private float _sliderFloat;

    public void ToggleClosed()
    {
        _isWindowOpen = !_isWindowOpen;
    }
    
    public void Draw()
    {
        if (!_isWindowOpen) return;
        
        ImGui.SetNextWindowSize(new Vector2(400, 300), ImGuiCond.Appearing);
        ImGui.Begin("Old Dev Tools", ref _isWindowOpen);

        if (ImGui.Button("Test button")) { Console.WriteLine("Test button clicked!"); }
        
        ImGui.Checkbox("Test checkbox", ref _checkbox);
        ImGui.SliderFloat("Test slider", ref _sliderFloat, 0, 100);

        ImGui.End();
    }
}
