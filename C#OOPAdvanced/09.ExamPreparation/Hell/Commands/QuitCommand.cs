using System.Collections.Generic;
using Hell.Contracts;

public class QuitCommand : AbstractCommand
{
    private IManager manager;
    
    public QuitCommand(List<string> args, IManager manager)
    {
        this.manager = manager;
    }

    public virtual string Execute()
    {
        //return base.Manager.Quit(this.ArgsList);
        return "";
    }
}