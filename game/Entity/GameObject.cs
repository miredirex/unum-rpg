using SFML.Graphics;
using SFML.System;

namespace unum
{
    public class GameObject : Transformable, Drawable
    {
        private const float SpriteScaling = 3f;
        protected Sprite EntitySprite = new Sprite {Scale = new Vector2f(SpriteScaling, SpriteScaling)};

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform = this.Transform;
            EntitySprite.Draw(target, states);
        }

        public virtual void Update(float deltaTime) { }

        public virtual void Start() { }
    }
}
