using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace unum
{
    public static class GameWindow
    {
        private const string GameTitle = "Unum RPG";
        private static readonly Vector2u WindowSize = new Vector2u(1280, 720);
        private static readonly Vector2i CenteredWindowPosition = new Vector2i(
            (int) VideoMode.DesktopMode.Width / 2 - (int) WindowSize.X / 2,
            (int) VideoMode.DesktopMode.Height / 2 - (int) WindowSize.Y / 2);
        public const uint TargetFps = 60;
        public static readonly RenderWindow Window = new RenderWindow(VideoMode.DesktopMode, GameTitle);

        static GameWindow()
        {
            SetWindowSettings();
            SetWindowCallbacks();
            SetupCursor();
        }
        
        private static void SetWindowSettings()
        {
            Window.Size = WindowSize;
            Window.Position = CenteredWindowPosition;
        }

        private static void SetWindowCallbacks()
        {
            Window.Closed += delegate { Window.Close(); };
            Window.MouseButtonPressed += delegate { Window.SetMouseCursor(Cursors.CursorClicked); };
            Window.MouseButtonReleased += delegate { Window.SetMouseCursor(Cursors.CursorDefault); };
        }

        private static void SetupCursor()
        {
            Window.SetMouseCursor(Cursors.CursorDefault);
        }
    }
}
