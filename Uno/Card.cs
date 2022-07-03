namespace Uno
{
    public class Card
    {
        public Color Color;

        public int Rank;

        public Card(Color color, int rank)
        {
            Color = color;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"{Color} {Rank}";
        }
    }
}