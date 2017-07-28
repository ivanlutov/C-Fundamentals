using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CardCompareTo
{
    public class Startup
    {
        public static void Main()
        {
            SortedSet<Card> cards = new SortedSet<Card>();

            var rankFirstCardToString = Console.ReadLine();
            var suitFirstCardToString = Console.ReadLine();
            Rank rankFirstCard = (Rank)Enum.Parse(typeof(Rank), rankFirstCardToString);
            Suit suitFirstCard = (Suit)Enum.Parse(typeof(Suit), suitFirstCardToString);
            var firstCard = new Card(rankFirstCard, suitFirstCard);
            cards.Add(firstCard);

            var rankSecondCardToString = Console.ReadLine();
            var suitSecondCardToString = Console.ReadLine();
            Rank rankSecondCard = (Rank)Enum.Parse(typeof(Rank), rankSecondCardToString);
            Suit suitSecondCard = (Suit)Enum.Parse(typeof(Suit), suitSecondCardToString);
            var secondCard = new Card(rankSecondCard, suitSecondCard);
            cards.Add(secondCard);

            Console.WriteLine(cards.Last());
        }
    }
}