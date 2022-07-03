using System;
using System.Collections.Generic;

namespace Uno
{
    public class Game
    {
        private readonly List<Player> _players = new List<Player>();

        public Deck Deck;

        private readonly List<Card> _desktop = new List<Card>();
        private Player _currentPlayer;

        private Card TopCard => _desktop[0];

        private bool IsPlayerHasCard(Player player)
        {
            foreach (var card in player.Hand.Cards)
            {
                if (card.Color == TopCard.Color || card.Rank == TopCard.Rank)
                {
                    return true;
                }
            }

            Console.WriteLine($"{player.Name} not have valid card.");
            return false;
        }


        public void Start()
        {
            PlayersNameHimSelf();
            Deck.Shuffle();
            Deal();
            StartRound();
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        private void TakesATurn(Player player)
        {
            if (IsPlayerHasCard(player))
            {
                if (VerifyCard(player.SelectCard()) == false)
                {
                    Console.WriteLine($"{player.Name} selected card is invalid.");
                    TakesATurn(player);
                    return;
                }

                Card card = player.ShowCard();
                _desktop.Insert(0, card);
                Console.WriteLine($"{player.Name} is show {card.ToString()}");
            }
            else
            {
                player.Hand.Cards.Add(Deck.DrawCard());
            }
        }

        private bool VerifyCard(Card showCard)
        {
            return showCard.Color == _desktop[0].Color || showCard.Rank > _desktop[0].Rank;
        }

        private void StartRound()
        {
            _desktop.Add(Deck.DrawCard());
            int index = 0;
            _currentPlayer = _players[index];

            while (true)
            {
                CheckDeckHasCard();
                TakesATurn(_currentPlayer);
                if (CheckWinner(_currentPlayer)) return;
                _currentPlayer = Next(ref index);
            }

            GameOver();
        }

        private void CheckDeckHasCard()
        {
            if (Deck.Count == 0)
            {
                Card topCard = TopCard;
                List<Card> turnToDeck = _desktop;
                turnToDeck.Remove(topCard);
                Deck.AddCards(turnToDeck).Shuffle();
                _desktop.Clear();
                _desktop.Add(topCard);
            }
        }

        private Player Next(ref int i)
        {
            return _players[i = i < _players.Count - 1 ? i + 1 : 0];
        }


        private void PlayersNameHimSelf()
        {
            foreach (Player player in _players)
            {
                player.NameHimSelf();
            }
        }

        void Deal()
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (Player player in _players)
                {
                    player.Hand.Cards.Add(Deck.DrawCard());
                }
            }
        }


        private bool CheckWinner(Player player)
        {
            return player.Hand.Cards.Count == 0;
        }

        private void GameOver()
        {
            Console.WriteLine("======== Game Over =======\n" +
                              $"Winner is {_currentPlayer.Name}");
        }
    }
}