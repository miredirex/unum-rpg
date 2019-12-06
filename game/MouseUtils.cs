using SFML.Graphics;
using SFML.Window;

namespace unum
{
    public static class MouseUtils
    {
        /// <summary>
        /// Checks if the mouse position is within rectangle's area
        /// </summary>
        public static bool IsMousePositionWithin(FloatRect rect)
        {
            var mousePos = Mouse.GetPosition(GameWindow.Window);
            return (mousePos.X >= rect.Left && mousePos.X <= rect.Width &&
                    mousePos.Y >= rect.Top && mousePos.Y <= rect.Height);
        }
    }
}
