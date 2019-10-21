using System.Collections.Generic;
using SFML.Graphics;

namespace unum
{
    public static class World
    {
        private static List<GameObject> GameObjects { get; } = new List<GameObject>();

        public static void AddObject(GameObject obj)
        {
            GameObjects.Add(obj);
        }

        public static void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var obj in GameObjects)
            {
                obj.Draw(target, states);
            }
        }
    }
}