using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace unum
{
    public class GameObject : Transformable, Drawable, IClickable
    {
        private const float SpriteScaling = 3f;
        protected Sprite Sprite = new Sprite { Scale = new Vector2f(SpriteScaling, SpriteScaling) };
        protected FloatRect BoundingBox => new FloatRect(Position, Position + (Vector2f)Sprite.Texture.Size * SpriteScaling);

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform = this.Transform;
            Sprite.Draw(target, states);
        }
        
        public void _Update(float deltaTime)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && MouseUtils.IsMousePositionWithin(this.BoundingBox))
            {
                OnMouseClickWithin(Mouse.GetPosition());
            }
            Update(deltaTime);
        }

        public virtual void Start() { }
        
        protected virtual void Update(float deltaTime) { }
        
        public virtual void OnMouseClickWithin(Vector2i mousePos) { }
    }
}
