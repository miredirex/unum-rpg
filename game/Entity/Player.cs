using SFML.Graphics;
using SFML.System;

namespace unum
{
    public class Player : GameObject
    {
        public Player()
        {
            EntitySprite.Texture = new Texture(Resources.PlayerTexture);
        }

        public override void Start()
        {
            
        }

        public override void Update(float deltaTime)
        {
            // It's moving!
            Position += new Vector2f(100f * deltaTime, 100f * deltaTime);
        }
    }
}
