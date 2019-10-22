using System;
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
        private static readonly Vector2u WindowSize = new Vector2u(640, 480);
        private static readonly RenderWindow GameWindow = new RenderWindow(VideoMode.DesktopMode, GameTitle);
        private readonly View CameraView = new View(new FloatRect(0, 0, WindowSize.X, WindowSize.Y));

        private readonly World GameWorld = new World()
            .AddObject(new Player());

        public Game()
        {
            SetWindowSettings(GameWindow);
            BindWindowCallbacks(GameWindow);
            GameLoop();
        }
        
        private void GameLoop()
        {
            //todo: calculate delta time
            while (GameWindow.IsOpen)
            {
                ProcessEvents();
                Update();
                Render();
            }
        }

        private void ProcessEvents()
        {
            GameWindow.DispatchEvents();
        }

        private void Update()
        {
            GameWindow.Clear();
            GameWorld.Update(GameWindow, RenderStates.Default);
        }

        private void Render()
        {
            GameWindow.Display();
        }

        private void HandleInput(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.Code);
        }

        private void SetWindowSettings(RenderWindow window)
        {
            window.Size = WindowSize;
            window.SetFramerateLimit(TargetFps);
            window.SetVerticalSyncEnabled(true);
            window.SetView(CameraView);
        }

        private void BindWindowCallbacks(RenderWindow window)
        {
            window.KeyPressed += HandleInput;
            window.Closed += (sender, args) => { ((Window)sender).Close(); };
        }
    }
}
