using System;
using System.Linq;

public class Engine
{
    public void Run()
    {
        var input = Console.ReadLine();
        var nationBuilder = new NationsBuilder();

        while (input != "Quit")
        {
            var tokens = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            var cmd = tokens[0];

            switch (cmd)
            {
                case "Bender":
                    nationBuilder.AssignBender(tokens);
                    break;
                case "Monument":
                    nationBuilder.AssignMonument(tokens);
                    break;
                case "Status":
                    var nationName = tokens[1];
                    var result = nationBuilder.GetStatus(nationName);
                    Console.WriteLine(result);
                    break;
                case "War":
                    nationName = tokens[1];
                    nationBuilder.IssueWar(nationName);
                    break;
            }

            input = Console.ReadLine();
        }

        var warsString = nationBuilder.GetWarsRecord();
        Console.WriteLine(warsString);
    }
}

