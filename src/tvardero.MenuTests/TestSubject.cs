using System.Numerics;
using ImGuiNET;
using Microsoft.Extensions.Logging;
using tvardero.DearDevTools.Components;

namespace tvardero.MenuTests;

public class TestSubject : ImGuiWindowWithLeftPanelBase
{
    public TestSubject() : base("Test subject") { }

    /// <inheritdoc />
    protected override void OnDrawLeftPanel() { }

    /// <inheritdoc />
    protected override void OnDrawMiddleContent() { }
}