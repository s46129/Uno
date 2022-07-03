using System;

namespace Uno.PlayerType
{
    public class AIPlayer : Player
    {
        private static int _aiIndex = 1;

        public override void NameHimSelf()
        {
            string aiName = $"AI{_aiIndex}";
            Console.WriteLine($"Set AI name {aiName}");
            Name = aiName;
            _aiIndex++;
        }

        public override Card SelectCard()
        {
            _selectedCard = Hand.Cards[new Random().Next(Hand.Cards.Count)];
            Console.WriteLine($"{Name} selected card.");
            return _selectedCard;
        }
    }
}