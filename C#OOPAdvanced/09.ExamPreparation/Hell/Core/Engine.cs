using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private IInputReader reader;
    private IOutputWriter writer;
    private HeroManager heroManager;

    public Engine(IInputReader reader, IOutputWriter writer, HeroManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            List<string> arguments = this.parseInput(inputLine);
            this.writer.WriteLine(this.processInput(arguments));
            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> parseInput(string input)
    {
        return input.Split(' ').ToList();
    }

    private string processInput(List<string> arguments)
    {
        string result = string.Empty;
        string command = arguments[0];
        arguments.RemoveAt(0);
        
        switch (command)
        {
            case "Hero":
                result =  heroManager.AddHero(arguments);
                break;
            case "Item":
                var hero = heroManager.heroes[arguments[1]];
                result = heroManager.AddItemToHero(arguments, hero);
                break;
            case "Recipe":
                result = heroManager.AddRecipeToHero(arguments);
                break;
            case "Inspect":
                result = heroManager.Inspect(arguments);
                break;
            case "Quit":
                result = heroManager.PrintAllHeroes();
                break;
            default:
                throw new InvalidOperationException();
        }

        return result;
        //Type commandType = Type.GetType(command + "Command");
        //var constructor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(IManager) });
        //ICommand cmd = (ICommand)constructor.Invoke(new object[] { arguments, this.heroManager });
        //return cmd.Execute();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}