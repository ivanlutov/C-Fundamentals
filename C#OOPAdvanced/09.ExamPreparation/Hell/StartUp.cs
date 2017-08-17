public class StartUp
{
    public static void Main()
    {
        ItemFactory itemFactory = new ItemFactory();
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();
        IInventory inventory = new HeroInventory();
        HeroManager manager = new HeroManager(itemFactory, inventory);

        Engine engine = new Engine(reader, writer, manager);
        engine.Run();
    }
}