﻿using System.Collections.Generic;
using SFML.Graphics;

namespace unum
{
    public class World
    {
        private List<GameObject> WorldObjects { get; } = new List<GameObject>();

        public World AddObject(GameObject obj)
        {
            WorldObjects.Add(obj);
            obj.Start();

            return this; //to invoke many AddObject at once
        }

        public void Update(RenderTarget target, RenderStates states)
        {
            foreach (var obj in WorldObjects)
            {
                obj.Update();
                obj.Draw(target, states);
            }
        }
    }
}
