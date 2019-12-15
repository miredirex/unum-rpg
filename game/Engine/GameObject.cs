using SFML.Graphics;
using SFML.System;
using SFMLMouse = SFML.Window.Mouse;

namespace unum.Engine
{
    public class GameObject : Transformable, Drawable
    {
        protected static Vector2f DefaultSpriteScale = new Vector2f(Settings.SpriteScale, Settings.SpriteScale);
        protected readonly Sprite Sprite = new Sprite { Scale = DefaultSpriteScale };
        
        protected FloatRect BoundingBox 
            => new FloatRect(Position, (Vector2f)Sprite.Texture.Size * Settings.SpriteScale);

        protected Vector2f CenterPosition 
            => new Vector2f(Position.X + BoundingBox.Width / 2f, Position.Y + BoundingBox.Height / 2f);

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
            if (SFMLMouse.IsButtonPressed(SFMLMouse.Button.Left) && Mouse.IsMousePositionWithin(this.BoundingBox))
            {
                OnMouseClickWithin(SFMLMouse.GetPosition());
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
