using System.Collections.Generic;
using SFML.Graphics;

namespace unum
{
    public class World
    {
        private List<GameObject> WorldObjects { get; } = new List<GameObject>();

        /// <summary>
        /// Adds object into the world and invokes its Start method
        /// </summary>
        /// <param name="obj">Game object to add into the world</param>
        /// <returns>Self so you can continue adding more</returns>
        public World AddObject(GameObject obj)
        {
            WorldObjects.Add(obj);
            obj.Start();

            return this;
        }

        /// <summary>
        /// Invokes update methods of all objects in the world
        /// </summary>
        /// <param name="deltaTime"></param>
        public void UpdateObjects(float deltaTime)
        {
            foreach (var obj in WorldObjects)
            {
                obj._Update(deltaTime);
            }
        }

        /// <summary>
        /// Draws all objects on screen
        /// </summary>
        public void RenderObjects(RenderTarget target, RenderStates states)
        {
            foreach (var obj in WorldObjects)
            {
                obj.Draw(target, states);
            }
        }
    }
}
