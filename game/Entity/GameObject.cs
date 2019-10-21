using SFML.Graphics;
using SFML.System;

namespace unum
{
    public class GameObject : Transformable, Drawable
    {
        protected Sprite EntitySprite = new Sprite { Scale = new Vector2f(2f, 2f) };

        protected GameObject()
        {
            World.AddObject(this);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            EntitySprite.Draw(target, states);
        }
    }
}