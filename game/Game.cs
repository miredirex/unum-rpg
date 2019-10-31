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
        private float _timeSinceLastUpdate = 0f;
        
        private readonly Clock _gameClock = new Clock();
        private readonly View _cameraView = new View(new FloatRect(0, 0, Window.Size.X, Window.Size.Y));
        
        private readonly World _gameWorld = new World()
            .AddObject(new Player());

        public Game()
        {
            SetupWindow();
            GameLoop();
        }

        private void SetupWindow()
        {
            Window.SetView(_cameraView);
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
            var dt = _gameClock.Restart().AsSeconds();
            _timeSinceLastUpdate += dt;
            if (_timeSinceLastUpdate > FixedTimestep)
            {
                _timeSinceLastUpdate -= FixedTimestep;
                
                _gameWorld.UpdateObjects(FixedTimestep);
            }
        }

        private void Render()
        {
            Window.Clear();
            _gameWorld.RenderObjects(Window, RenderStates.Default);
            Window.Display();
        }

        private void HandleInput(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.Code);
        }
    }
}
