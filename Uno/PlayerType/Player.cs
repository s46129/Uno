namespace Uno
{
    public abstract class Player
    {
        public string Name;

        public Hand Hand = new Hand();

        protected Card _selectedCard;
        public abstract void NameHimSelf();

        public Card ShowCard()
        {
            Hand.Cards.Remove(_selectedCard);
            return _selectedCard;
        }

        public abstract Card SelectCard();
    }
}