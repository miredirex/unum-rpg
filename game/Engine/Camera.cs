using System;
using SFML.System;

namespace unum.Engine
{
    public static class Camera
    {
        private const float SmoothBalancingFactor = 3f;
        private static float _zoomFactor = 1f;
        public static float ZoomFactor
        {
            get => _zoomFactor;
            set
            {
                if (_zoomFactor >= value && value > 1) return;
                if (_zoomFactor <= value && value < 1) return;
                _zoomFactor *= value;
                GameWindow.Window.GetView().Zoom(1 / value);
            }
        }

        /// <summary>
        /// Camera's center position.
        /// </summary>
        public static Vector2f Position
        {
            get => GameWindow.Window.GetView().Center;
            set => GameWindow.Window.GetView().Center = value;
        }

        /// <summary>
        /// Zooms camera in specified position
        /// </summary>
        /// <param name="zoomInto">(x, y) to zoom into</param>
        /// <param name="zoomFactor">Zoom factor. Non-negative value! (0-3 is recommended).
        /// Use [0;1) to zoom out, (1;+inf) to zoom in</param>
        public static void Zoom(Vector2f zoomInto, float zoomFactor)
        {
            ZoomFactor = zoomFactor;
            Position = zoomInto;
        }

        /// <summary>
        /// Smoothly zooms camera in specified position
        /// </summary>
        /// <param name="zoomInto">(x, y) to zoom into</param>
        /// <param name="zoomFactor">Zoom factor. Non-negative value! (0-3 is recommended).
        /// Use [0;1) to zoom out, (1;+inf) to zoom in</param>
        /// <param name="delta">Current delta value</param>
        public static void ZoomSmooth(Vector2f zoomInto, float zoomFactor, float delta)
        {
            Position = MathHelper.Lerp(Position, zoomInto, delta);
            if (_zoomFactor >= zoomFactor && zoomFactor > 1) return;
            if (_zoomFactor <= zoomFactor && zoomFactor < 1) return;
            _zoomFactor *= 1 + Math.Sign(zoomFactor - 1f) * delta / SmoothBalancingFactor;
            Console.WriteLine(_zoomFactor);
            GameWindow.Window.GetView().Zoom(1 / (1 + Math.Sign(zoomFactor - 1f) * delta / SmoothBalancingFactor));
        }
    }
}
