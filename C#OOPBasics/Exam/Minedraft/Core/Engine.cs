using System;
using System.Linq;

public class Engine
{
    private DraftManager manager;
    private bool isRunning;

    public Engine()
    {
        this.manager = new DraftManager();
        this.isRunning = true;
    }
    public void Run()
    {
        while (isRunning)
        {
            var cmdArgs = Console.ReadLine().Split().ToList();
            var command = cmdArgs[0];
            cmdArgs.RemoveAt(0);

            switch (command)
            {
                case "RegisterHarvester":
                    var resultHarvester = manager.RegisterHarvester(cmdArgs);
                    Console.WriteLine(resultHarvester);
                    break;
                case "RegisterProvider":
                    var resultProvider = manager.RegisterProvider(cmdArgs);
                    Console.WriteLine(resultProvider);
                    break;
                case "Day":
                    Console.WriteLine(manager.Day());
                    break;
                case "Mode":
                    var mode = manager.Mode(cmdArgs);
                    Console.WriteLine(mode);
                    break;
                case "Check":
                    var result = manager.Check(cmdArgs);
                    Console.WriteLine(result);
                    break;
                case "Shutdown":
                    Console.WriteLine(manager.ShutDown());
                    isRunning = false;
                    break;
            }
        }
    }
}
