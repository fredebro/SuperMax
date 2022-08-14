using DIKUArcade.GUI;

namespace SuperMarioBroski
{
    class Program
    {
        static void Main(string[] args)
        {
            var winArgs = new WindowArgs() {
                Width = 1000u,
                Height = 1000u
            };
            var game = new Game(winArgs);
            game.Run();
        }
    }
}
