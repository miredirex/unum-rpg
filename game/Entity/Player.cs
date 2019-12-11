using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using unum.Engine;

namespace unum
{
    public class Player : GameObject
    {
        private const float Velocity = 100f;

        public override void Start()
        {
            Sprite.Texture = new Texture(Resources.Files.PlayerTexture);
        }

        protected override void Update(float deltaTime)
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

        protected override void OnMouseClickWithin(Vector2i mousePos)
        {
            Console.WriteLine("CLICKED!");
            Console.WriteLine(mousePos.ToString());
        }
    }
}
