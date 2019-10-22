using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace unum
{
    public class Game
    {
        private static readonly RenderWindow Window = GameWindow.Window;
        private const float FixedTimestep = 1f / GameWindow.TargetFps; // 1/60 (60 fps)
        private float TimeSinceLastUpdate = 0f;
        
        private readonly Clock GameClock = new Clock();
        private readonly View CameraView = new View(new FloatRect(0, 0, Window.Size.X, Window.Size.Y));
        
        private readonly World GameWorld = new World()
            .AddObject(new Player());

        public Game()
        {
            SetupWindow();
            GameLoop();
        }

        private void SetupWindow()
        {
            Window.SetView(CameraView);
        }
        
        private void GameLoop()
        {
            while (Window.IsOpen)
            {
                ProcessEvents();
                Update();
                Render();
            }
        }

        private void ProcessEvents()
        {
            Window.DispatchEvents();
        }

        private void Update()
        {
            var dt = GameClock.Restart().AsSeconds();
            TimeSinceLastUpdate += dt;
            if (TimeSinceLastUpdate > FixedTimestep)
            {
                TimeSinceLastUpdate -= FixedTimestep;
                
                GameWorld.UpdateObjects(FixedTimestep);
            }
        }

        private void Render()
        {
            Window.Clear();
            GameWorld.RenderObjects(Window, RenderStates.Default);
            Window.Display();
        }

        private void HandleInput(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.Code);
        }
    }
}
