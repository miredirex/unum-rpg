using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace unum
{
    public class GameObject : Transformable, Drawable
    {
        private const float SpriteScale = 3f;
        protected Sprite Sprite = new Sprite { Scale = new Vector2f(SpriteScale, SpriteScale) };
        protected FloatRect BoundingBox => new FloatRect(Position, Position + (Vector2f)Sprite.Texture.Size * SpriteScale);

        /// <summary>
        /// Draws this object on screen
        /// </summary>
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform = this.Transform;
            Sprite.Draw(target, states);
        }
        
        /// <summary>
        /// Invokes every frame of the game loop and before each of the game objects' Update() methods
        /// </summary>
        public void _Update(float deltaTime)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && MouseUtils.IsMousePositionWithin(this.BoundingBox))
            {
                OnMouseClickWithin(Mouse.GetPosition());
            }
            Update(deltaTime);
        }

        /// <summary>
        /// Invokes once when the object is added into the world.
        /// </summary>
        public virtual void Start() { }
        
        /// <summary>
        /// Invokes every frame of the game loop.
        /// </summary>
        /// <param name="deltaTime">Difference in milliseconds between the last frame and the current</param>
        protected virtual void Update(float deltaTime) { }
        
        /// <summary>
        /// Fires every time the mouse is clicked within an object's bounding box
        /// </summary>
        /// <param name="mousePos">Mouse click position</param>
        protected virtual void OnMouseClickWithin(Vector2i mousePos) { }
    }
}
