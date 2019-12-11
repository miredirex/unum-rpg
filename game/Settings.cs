using SFML.System;
using unum.Engine;

namespace unum
{
    public struct Settings
    {
        public const string GameTitle = "Unum RPG";
        public const uint TargetFps = 60;
        public const uint SpriteScale = 3;
        public static readonly Vector2u WindowSize = new Vector2u(1280, 720);
        public static readonly SFML.Window.Cursor CursorDefault;
        public static readonly SFML.Window.Cursor CursorClicked;

        static Settings()
        {
            CursorClicked = Cursor.CreateCursorFromSquareImage(Resources.Files.ClickedCursor);
            CursorDefault = Cursor.CreateCursorFromSquareImage(Resources.Files.DefaultCursor);
        }
    }
}
