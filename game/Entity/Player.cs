using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace unum
{
    public class Player : GameObject
    {
        private const float Velocity = 100f;
        public Player()
        {
            EntitySprite.Texture = new Texture(Resources.PlayerTexture);
        }

        public override void Start()
        {
            
        }

        public override void Update(float deltaTime)
        {
            Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                Position += new Vector2f(0f, -Velocity * deltaTime);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                Position += new Vector2f(-Velocity * deltaTime, 0f);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                Position += new Vector2f(0f, Velocity * deltaTime);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                Position += new Vector2f(Velocity * deltaTime, 0f);   
            }
        }
    }
}
