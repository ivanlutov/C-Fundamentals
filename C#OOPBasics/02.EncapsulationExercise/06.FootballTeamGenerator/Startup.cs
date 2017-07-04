using System;
using System.Collections.Generic;

namespace _06.FootballTeamGenerator
{
    public class Startup
    {
        private static Dictionary<string, Team> teams = new Dictionary<string, Team>();

        public static void Main()
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var cmd = tokens[0];
                try
                {
                    switch (cmd)
                    {
                        case "Team":
                            CreateTeam(tokens[1]);
                            break;

                        case "Add":
                            AddPlayerToTeam(tokens[1], tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));
                            break;

                        case "Remove":
                            RemovePlayerFromTeam(tokens[1], tokens[2]);
                            break;

                        case "Rating":
                            PrintRating(tokens[1]);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintRating(string teamName)
        {
            if (!teams.ContainsKey(teamName))
            {
                throw new InvalidOperationException($"Team {teamName} does not exist.");
            }

            var team = teams[teamName];
            Console.WriteLine(team);
        }

        private static void RemovePlayerFromTeam(string teamName, string playerName)
        {
            if (!teams.ContainsKey(teamName))
            {
                throw new InvalidOperationException($"Team {teamName} does not exist.");
            }

            Team team = teams[teamName];
            team.RemovePlayer(playerName);
        }

        private static void AddPlayerToTeam(string teamName, string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            if (!teams.ContainsKey(teamName))
            {
                throw new InvalidOperationException($"Team {teamName} does not exist.");
            }

            Player player = new Player(
                playerName,
                new Stat("Endurance", endurance),
                new Stat("Sprint", sprint),
                new Stat("Dribble", dribble),
                new Stat("Passing", passing),
                new Stat("Shooting", shooting));
            Team team = teams[teamName];

            team.AddPlayer(player);
        }

        private static void CreateTeam(string name)
        {
            Team team = new Team(name);
            teams.Add(name, team);
        }
    }
}