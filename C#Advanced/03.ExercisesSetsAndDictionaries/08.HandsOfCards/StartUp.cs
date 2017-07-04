using System;
using System.Collections.Generic;

namespace _08.HandsOfCards
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, HashSet<string>> players = new Dictionary<string, HashSet<string>>();

            while (input != "JOKER")
            {
                var inputLine = input.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var name = inputLine[0];
                var cardTokens = inputLine[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (!players.ContainsKey(name))
                {
                    players[name] = new HashSet<string>();
                }
                for (int i = 0; i < cardTokens.Length; i++)
                {
                    players[name].Add(cardTokens[i]);
                }

                input = Console.ReadLine();
            }

            foreach (var player in players)
            {
                var points = CalculateCards(player.Value);
                Console.WriteLine($"{player.Key}: {points}");
            }
        }

        public static int CalculateCards(HashSet<string> cards)
        {
            int points = 0;
            int intPower = 0;
            int intType = 0;

            foreach (var card in cards)
            {
                var power = card.Substring(0, card.Length - 1);
                var type = card.Substring(card.Length - 1);

                switch (power)
                {
                    case "J":
                        intPower = 11;
                        break;

                    case "Q":
                        intPower = 12;
                        break;

                    case "K":
                        intPower = 13;
                        break;

                    case "A":
                        intPower = 14;
                        break;

                    default:
                        intPower = int.Parse(power);
                        break;
                }
                switch (type)
                {
                    case "S":
                        intType = 4;
                        break;

                    case "H":
                        intType = 3;
                        break;

                    case "D":
                        intType = 2;
                        break;

                    case "C":
                        intType = 1;
                        break;
                }

                points += intPower * intType;
            }

            return points;
        }
    }
}