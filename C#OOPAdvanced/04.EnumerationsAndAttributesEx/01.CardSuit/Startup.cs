using System;

public class Startup
{
    public static void Main()
    {
        Array suits = Enum.GetValues(typeof(Suit));

        Console.WriteLine("Card Suits:");
        foreach (var cardSuit in suits)
        {
            Console.WriteLine($"Ordinal value: {(int)cardSuit}; Name value: {cardSuit}");
        }
    }
}