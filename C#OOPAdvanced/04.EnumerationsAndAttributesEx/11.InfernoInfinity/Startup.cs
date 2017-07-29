namespace _11.InfernoInfinity
{
    public class Startup
    {
        public static void Main()
        {
            var commandInterpreter = new CommandInterpreter();
            commandInterpreter.StartReadingCommands();
        }
    }
}