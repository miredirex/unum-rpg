using unum.Engine;

namespace unum
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWorld world = new NewWorld();
            var game = new Game(world);
        }
    }
}
