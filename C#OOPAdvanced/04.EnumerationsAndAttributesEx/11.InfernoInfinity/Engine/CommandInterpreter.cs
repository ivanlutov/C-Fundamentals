using System;
using System.Linq;

public class CommandInterpreter
{
    private readonly WeaponManager weaponManager = new WeaponManager();

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            var input = Console.ReadLine();
            var tokens = input.Split(';');
            var cmd = tokens[0];
            var arguments = tokens.Skip(1).ToList();

            switch (cmd)
            {
                case "Create":
                    weaponManager.Create(arguments);
                    break;

                case "Add":
                    weaponManager.Add(arguments);
                    break;

                case "Remove":
                    weaponManager.Remove(arguments);
                    break;

                case "Print":
                    Console.WriteLine(weaponManager.Print(arguments[0]));
                    break;

                case "END":
                    isRunning = false;
                    break;
            }
        }
    }
}