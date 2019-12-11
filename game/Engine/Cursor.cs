using System;
using SFML.Graphics;
using SFML.System;

namespace unum.Engine
{
    public static class Cursor
    {
        private const int PngChannelsCount = 4;

        /// <summary>
        /// Creates and configures SFML Cursor from image file
        /// </summary>
        /// <param name="filePath">Path to the image file</param>
        /// <exception cref="InvalidOperationException">The exception is thrown when the image is not square</exception>
        public static SFML.Window.Cursor CreateCursorFromSquareImage(string filePath)
        {
            var pixels = new Image(filePath).Pixels;
            var cursorSize = Math.Sqrt(pixels.Length / PngChannelsCount);
            if (cursorSize % 1 != 0)
            {
                throw new InvalidOperationException("Width and height of the cursor image should be the same");
            }
            return new SFML.Window.Cursor(pixels, new Vector2u((uint)cursorSize, (uint)cursorSize), new Vector2u());
        }
    }
}
