using SFML.Graphics;

namespace unum.Engine
{
    public static class Mouse
    {
        /// <summary>
        /// Checks if the mouse position is within rectangle's area
        /// </summary>
        public static bool IsMousePositionWithin(FloatRect rect)
        {
            var mousePos = SFML.Window.Mouse.GetPosition(GameWindow.Window);
            return (mousePos.X >= rect.Left && mousePos.X <= rect.Width &&
                    mousePos.Y >= rect.Top && mousePos.Y <= rect.Height);
        }
    }
}
