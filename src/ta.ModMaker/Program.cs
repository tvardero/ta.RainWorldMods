using System.Drawing;
using ImGuiNET;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using Silk.NET.Windowing;
using ta.ModMaker;

var windowOptions = WindowOptions.Default;

var window = Window.Create(windowOptions);

GL gl = null!;
IInputContext input = null!;
ImGuiController imGuiController = null!;
IKeyboard keyboard = null!;
ImGuiIOPtr imguiIo = 0;

var oldDevTools = new DrawImGui();

window.Load += () =>
{
    gl = window.CreateOpenGL();

    input = window.CreateInput();
    input.Mice[0].Cursor.CursorMode = CursorMode.Hidden;
    keyboard = input.Keyboards[0];

    keyboard.KeyChar += (_, ch) =>
    {
        if (ch == 'h') oldDevTools.ToggleClosed();
    };

    imGuiController = new ImGuiController(gl, window, input);

    imguiIo = ImGui.GetIO();
    imguiIo.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
    imguiIo.MouseDrawCursor = true;
};

window.FramebufferResize += size => gl.Viewport(size);

window.Render += delta =>
{
    gl.ClearColor(Color.DarkGray);
    gl.Clear(ClearBufferMask.ColorBufferBit);

    imGuiController.Update((float)delta);

    imguiIo.AddKeyEvent(ImGuiKey.ModAlt, keyboard.IsKeyPressed(Key.AltLeft) || keyboard.IsKeyPressed(Key.AltRight));
    imguiIo.AddKeyEvent(ImGuiKey.ModSuper, keyboard.IsKeyPressed(Key.SuperLeft) || keyboard.IsKeyPressed(Key.SuperRight));
    imguiIo.AddKeyEvent(ImGuiKey.ModCtrl, keyboard.IsKeyPressed(Key.ControlLeft) || keyboard.IsKeyPressed(Key.ControlRight));
    imguiIo.AddKeyEvent(ImGuiKey.ModShift, keyboard.IsKeyPressed(Key.ShiftLeft) || keyboard.IsKeyPressed(Key.ShiftRight));

    oldDevTools.Draw();

    imGuiController.Render();
};

window.Closing += () =>
{
    imGuiController.Dispose();
    input.Dispose();
    gl.Dispose();
};

window.Run();
window.Dispose();
