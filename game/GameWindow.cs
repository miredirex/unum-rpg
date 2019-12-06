using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace unum
{
    public static class GameWindow
    {
        private const string GameTitle = "Unum RPG";
        private static readonly Vector2u WindowSize = new Vector2u(640, 480);
        public const uint TargetFps = 60;
        public static readonly RenderWindow Window = new RenderWindow(VideoMode.DesktopMode, GameTitle);

        static GameWindow()
        {
            SetWindowSettings();
            SetWindowCallbacks();
        }
        
        private static void SetWindowSettings()
        {
            Window.Size = WindowSize;
            //window.SetFramerateLimit(TargetFps);
            //window.SetVerticalSyncEnabled(true);
        }

        private static void SetWindowCallbacks()
        {
            Window.Closed += (sender, args) => { Window.Close(); };
        }
    }
}
