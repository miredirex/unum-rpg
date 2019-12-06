using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace unum
{
    public static class Cursors
    {
        private const uint CursorSize = 32u;

        private static readonly byte[] DefaultCursorPixels = new Image(Resources.Files.DefaultCursor).Pixels;
        private static readonly byte[] ClickedCursorPixels = new Image(Resources.Files.ClickedCursor).Pixels;

        public static Cursor CursorDefault => new Cursor(DefaultCursorPixels, new Vector2u(CursorSize, CursorSize), new Vector2u());
        public static Cursor CursorClicked => new Cursor(ClickedCursorPixels, new Vector2u(CursorSize, CursorSize), new Vector2u());
    }
}
