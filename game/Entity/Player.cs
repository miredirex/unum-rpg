using SFML.Graphics;

namespace unum
{
    public class Player : GameObject
    {
        public Player()
        {
            //todo: use assets (or static class)
            EntitySprite.Texture = new Texture("herotest.png");
        }
    }
}