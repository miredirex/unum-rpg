using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace unum.Engine
{
    public static class GameWindow
    {
        public static readonly RenderWindow Window = new RenderWindow(VideoMode.DesktopMode, Settings.GameTitle);
        
        private static readonly Vector2i CenteredWindowPosition = new Vector2i(
            (int) VideoMode.DesktopMode.Width / 2 - (int) Settings.WindowSize.X / 2,
            (int) VideoMode.DesktopMode.Height / 2 - (int) Settings.WindowSize.Y / 2);

        static GameWindow()
        {
            SetWindowSettings();
            SetWindowCallbacks();
            SetupCursor();
        }
        
        private static void SetWindowSettings()
        {
            Window.Size = Settings.WindowSize;
            Window.Position = CenteredWindowPosition;
            Window.SetView(new View());
        }

        private static void SetWindowCallbacks()
        {
            Window.Closed += delegate { Window.Close(); };
            Window.MouseButtonPressed += delegate { Window.SetMouseCursor(Settings.CursorClicked); };
            Window.MouseButtonReleased += delegate { Window.SetMouseCursor(Settings.CursorDefault); };
            Window.Resized += WindowOnResizedAdjustView;
        }

        private static void SetupCursor()
        {
            Window.SetMouseCursor(Settings.CursorDefault);
        }
        
        private static void WindowOnResizedAdjustView(object sender, SizeEventArgs e)
        {
            var cameraView = new View(new FloatRect(0, 0, e.Width, e.Height));
            Window.SetView(cameraView);
        }

        public static void UpdateView()
        {
            Window.SetView(Window.GetView());
        }
    }
}
