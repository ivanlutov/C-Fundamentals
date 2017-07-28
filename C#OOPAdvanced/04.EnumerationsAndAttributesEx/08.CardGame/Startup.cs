
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CardGame
{
    public class Startup
    {
        public static void Main()
        {
            var cards = new List<Card>();
            var ranks = typeof(Rank).GetEnumValues();
            var suits = typeof(Suit).GetEnumValues();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    var card = new Card((Rank)rank, (Suit)suit);
                    cards.Add(card);
                }
            }

            var firstPlayerName = Console.ReadLine();
            var secondPlayerName = Console.ReadLine();
            var firstPlayerCards = new SortedSet<Card>();
            var secondPlayerCards = new SortedSet<Card>();

            while (firstPlayerCards.Count < 5)
            {
                var cardTokens = Console.ReadLine().Split();
                Rank? rank = null;
                Suit? suit = null;
                try
                {
                    rank = (Rank)Enum.Parse(typeof(Rank), cardTokens[0]);
                    suit = (Suit)Enum.Parse(typeof(Suit), cardTokens[2]);
                    var cardToAdd = cards.FirstOrDefault(c => c.Rank == rank && c.Suit == suit);

                    if (cardToAdd != null)
                    {
                        firstPlayerCards.Add(cardToAdd);
                        cards.Remove(cardToAdd);
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            while (secondPlayerCards.Count < 5)
            {
                var cardTokens = Console.ReadLine().Split();
                Rank? rank = null;
                Suit? suit = null;
                try
                {
                    rank = (Rank)Enum.Parse(typeof(Rank), cardTokens[0]);
                    suit = (Suit)Enum.Parse(typeof(Suit), cardTokens[2]);
                    var cardToAdd = cards.FirstOrDefault(c => c.Rank == rank && c.Suit == suit);

                    if (cardToAdd != null)
                    {
                        secondPlayerCards.Add(cardToAdd);
                        cards.Remove(cardToAdd);
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            var biggerCardFirstPlayer = firstPlayerCards.Last();
            var biggerCardSecondPlayer = secondPlayerCards.Last();

            if (biggerCardFirstPlayer.CompareTo(biggerCardSecondPlayer) == 1)
            {
                Console.WriteLine($"{firstPlayerName} wins with {biggerCardFirstPlayer}.");
            }
            else
            {
                Console.WriteLine($"{secondPlayerName} wins with {biggerCardSecondPlayer}.");
            }
        }
    }
}
