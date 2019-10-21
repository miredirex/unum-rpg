using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace unum
{
    public class Game
    {
        /* Window settings */
        private const string GameTitle = "Unum RPG";
        private const uint TargetFps = 60;
        private static readonly Vector2u WindowSize = new Vector2u(800, 600);
        private static readonly RenderWindow GameWindow = new RenderWindow(VideoMode.DesktopMode, GameTitle);
        private readonly View CameraView = new View(new FloatRect(0, 0, WindowSize.X, WindowSize.Y));

        private Player player = new Player();
        
        public Game()
        {
            SetWindowSettings(GameWindow);

            while (GameWindow.IsOpen)
            {
                GameLoop();
            }
        }
        
        //todo: finish drawing and handling input
        private void GameLoop()
        {
            ProcessEvents();
            GameWindow.Clear();
            World.Draw(GameWindow, RenderStates.Default);
            GameWindow.Display();
        }

        private void ProcessEvents()
        {
            
        }

        private void SetWindowSettings(RenderWindow window)
        {
            window.Size = WindowSize;
            window.SetFramerateLimit(TargetFps);
            window.SetVerticalSyncEnabled(true);
            window.SetView(CameraView);
        }
    }
}