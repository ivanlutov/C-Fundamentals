using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IEngine
{
    private readonly IInputReader reader;
    private readonly IOutputWriter writer;
    private readonly ICommandInterpreter commandInterpreter;

    public Engine(IInputReader reader, IOutputWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            IList<string> arguments = this.parseInput(inputLine);

            var result = commandInterpreter.InterpretCommand(arguments);

            if (result != string.Empty)
            {
                this.writer.WriteLine(result);
            }

            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private IList<string> parseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}