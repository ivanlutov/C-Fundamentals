using System;

namespace _07.DeckOfCards
{
    public class Startup
    {
        public static void Main()
        {
            var ranks = typeof(Rank).GetEnumValues();
            var suits = typeof(Suit).GetEnumValues();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Console.WriteLine($"{rank} of {suit}");
                }
            }
        }
    }
}