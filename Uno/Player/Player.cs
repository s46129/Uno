namespace Uno
{
    public abstract class Player
    {
        public string Name;

        public Hand Hand = new Hand();

        protected Card SelectedCard;
        public abstract void NameHimSelf();

        public Card ShowCard()  
        {
            Hand.Cards.Remove(SelectedCard);
            return SelectedCard;
        }

        public abstract Card SelectCard();
    }
}