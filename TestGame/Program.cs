using FinalEngine.Platform.Desktop.OpenTK;
using FinalEngine.Platform.Desktop.OpenTK.Invocation;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

var settings = new NativeWindowSettings()
{
    WindowBorder = WindowBorder.Fixed,
    WindowState = WindowState.Normal,

    Size = new Vector2i(1024, 768),

    StartVisible = true
};

var nativeWindow = new NativeWindowInvoker(new NativeWindow(settings));
var window = new OpenTKWindow(nativeWindow);

while (!window.IsExiting)
{
    window.ProcessEvents();
}

window.Dispose();