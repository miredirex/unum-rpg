using System.Collections.Generic;
using SFML.Graphics;

namespace unum.Engine
{
    public abstract class GameWorld
    {
        private List<GameObject> WorldObjects { get; } = new List<GameObject>();

        /// <summary>
        /// Adds object into the world and invokes its Start method
        /// </summary>
        /// <param name="obj">Game object to add into the world</param>
        public void AddObject(GameObject obj)
        {
            WorldObjects.Add(obj);
            obj.Start();
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
