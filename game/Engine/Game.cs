using SFML.Graphics;
using SFML.System;

namespace unum.Engine
{
    public class Game
    {
        public static Game Instance { get; private set; }
        private const float FixedTimestep = 1f / Settings.TargetFps; // 1/60 (60 fps)
        
        private readonly Clock _gameClock = new Clock();
        private float _timeSinceLastUpdate = 0f;
        public GameWorld CurrentWorld { get; private set; }

        public Game(GameWorld firstWorld)
        {
            Instance = this;
            CurrentWorld = firstWorld;
            GameLoop();
        }

        private void GameLoop()
        {
            while (GameWindow.Window.IsOpen)
            {
                ProcessEvents();
                Update();
                Render();
            }
        }

        private void ProcessEvents()
        {
            GameWindow.Window.DispatchEvents();
        }

        private void Update()
        {
            var dt = _gameClock.Restart().AsSeconds();
            _timeSinceLastUpdate += dt;
            if (_timeSinceLastUpdate > FixedTimestep)
            {
                _timeSinceLastUpdate -= FixedTimestep;
                
                CurrentWorld.UpdateObjects(FixedTimestep);
            }
        }

        private void Render()
        {
            GameWindow.Window.Clear();
            CurrentWorld.RenderObjects(GameWindow.Window, RenderStates.Default);
            GameWindow.Window.Display();
        }

        public void ProvideWorld(GameWorld world)
        {
            CurrentWorld = world;
        }
    }
}
