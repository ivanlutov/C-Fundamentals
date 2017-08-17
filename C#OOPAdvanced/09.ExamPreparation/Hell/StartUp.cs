public class StartUp
{
    public static void Main()
    {
        ItemFactory itemFactory = new ItemFactory();
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();
        HeroManager manager = new HeroManager(itemFactory);

        Engine engine = new Engine(reader, writer, manager);
        engine.Run();
    }
}