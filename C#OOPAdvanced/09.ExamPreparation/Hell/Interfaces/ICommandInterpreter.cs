using System.Collections.Generic;

public interface ICommandInterpreter
{
    string InterpretCommand(IList<string> args);
}