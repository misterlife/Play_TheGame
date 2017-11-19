using SiliconStudio.Xenko.Engine;

namespace Play_TheGame
{
    class Play_TheGameApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
