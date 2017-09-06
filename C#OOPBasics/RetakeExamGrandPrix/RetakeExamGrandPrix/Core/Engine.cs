using System;
using System.Linq;

public class Engine
{
    private readonly RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }
    public void Start()
    {
        var numberOfLaps = int.Parse(Console.ReadLine());
        var lengthOfTrack = int.Parse(Console.ReadLine());
        this.raceTower.SetTrackInfo(numberOfLaps, lengthOfTrack);

        var commandLine = Console.ReadLine();

        while (true)
        {
            var commandArgs = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var cmd = commandArgs.First();
            commandArgs.RemoveAt(0);

            switch (cmd)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(commandArgs);
                    break;
                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    var result = this.raceTower.CompleteLaps(commandArgs);
                    if (result != string.Empty)
                    {
                        Console.WriteLine(result);
                    }
                    if (this.raceTower.NumberOfLaps == 0)
                    {
                        Environment.Exit(0);
                    }
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(commandArgs);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(commandArgs);
                    break;
            }

            commandLine = Console.ReadLine();
        }
    }
}
