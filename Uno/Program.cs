using System.Xml;

namespace Uno
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.AddPlayer(new HumanPlayer());
            game.AddPlayer(new AIPlayer());
            game.AddPlayer(new AIPlayer());
            game.AddPlayer(new AIPlayer());
            game.Deck = new Deck();
            game.Start();

        }
    }
}