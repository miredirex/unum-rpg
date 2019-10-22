using SFML.Graphics;

namespace unum
{
    public class Player : GameObject
    {
        public Player()
        {
            EntitySprite.Texture = new Texture(Res.PlayerTexture);
        }

        public override void Update()
        {
            //todo: add basic movement
        }
    }
}
