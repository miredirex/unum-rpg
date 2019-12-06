﻿using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace unum
{
    public static class Cursors
    {
        private const int PngChannelsCount = 4;
        public static readonly Cursor CursorDefault = CreateCursorFromSquareImage(Resources.Files.DefaultCursor);
        public static readonly Cursor CursorClicked = CreateCursorFromSquareImage(Resources.Files.ClickedCursor);

        /// <summary>
        /// Creates and configures SFML Cursor from image file
        /// </summary>
        /// <param name="filePath">Path to the image file</param>
        /// <exception cref="InvalidOperationException">The exception is thrown when the image is not square</exception>
        public static Cursor CreateCursorFromSquareImage(string filePath)
        {    
            var pixels = new Image(filePath).Pixels;
            var cursorSize = Math.Sqrt(pixels.Length / PngChannelsCount);
            if (cursorSize % 1 != 0)
            {
                throw new InvalidOperationException("Width and height of the cursor image should be the same");
            }
            return new Cursor(pixels, new Vector2u((uint)cursorSize, (uint)cursorSize), new Vector2u());
        }
    }
}
