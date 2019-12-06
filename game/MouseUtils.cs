using SFML.Graphics;
using SFML.Window;

namespace unum
{
    public static class MouseUtils
    {
        public static bool IsMousePositionWithin(FloatRect rect)
        {
            var mousePos = Mouse.GetPosition(GameWindow.Window);
            return (mousePos.X >= rect.Left && mousePos.X <= rect.Width &&
                    mousePos.Y >= rect.Top && mousePos.Y <= rect.Height);
        }
    }
}
