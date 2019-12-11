using unum.Engine;

namespace unum
{
    public class NewWorld : GameWorld
    {
        /// <summary>
        /// Add your early game objects here in constructor
        /// </summary>
        public NewWorld()
        {
            AddObject(new Player());
        }
    }
}
