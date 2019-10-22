using System;
using SFML.Graphics;
using SFML.System;

namespace unum
{
    public class Player : GameObject
    {
        public Player()
        {
            EntitySprite.Texture = new Texture(Res.PlayerTexture);
        }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            // It's moving!
            Position += new Vector2f(1f, 1f);
        }
    }
}
