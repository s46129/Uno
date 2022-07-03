using System;

namespace Uno.PlayerType
{
    public class HumanPlayer : Player
    {
        public override void NameHimSelf()
        {
            Console.WriteLine("Set your name:");
            Name = Console.ReadLine();
        }

        public override Card SelectCard()
        {
            for (var index = 0; index < Hand.Cards.Count; index++)
            {
                Card card = Hand.Cards[index];
                Console.WriteLine($"{index}. {card.Color} {card.Rank}");
            }

            Console.WriteLine($"Input select ID(0~{Hand.Cards.Count - 1}):\n");
            int selectIndex = int.Parse(Console.ReadLine() ?? string.Empty);
            if (selectIndex < 0)
            {
                selectIndex = 0;
            }
            else if (selectIndex > Hand.Cards.Count)
            {
                selectIndex = Hand.Cards.Count - 1;
            }

            _selectedCard = Hand.Cards[selectIndex];
            return _selectedCard;
        }
    }
}