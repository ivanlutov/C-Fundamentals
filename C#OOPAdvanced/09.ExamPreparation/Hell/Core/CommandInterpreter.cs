using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string Suffix = "Command";
    private readonly IHeroManager heroManager;

    public CommandInterpreter(IHeroManager heroManager)
    {
        this.heroManager = heroManager;
    }

    public string InterpretCommand(IList<string> args)
    {
        ICommand command = this.ParseCommand(args);
        return command.Execute();
    }

    private ICommand ParseCommand(IList<string> args)
    {
        var commandName = args[0] + Suffix;
        args = args.Skip(1).ToList();

        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandName);
        if (type == null)
        {
            throw new InvalidOperationException("Invalid command!");
        }

        var data = new object[]
        {
            args
            ,this.heroManager
        };

        var currentInstance = (ICommand)Activator.CreateInstance(type, data);

        return currentInstance;
    }
}