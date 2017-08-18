public class StartUp
{
    public static void Main()
    {
        ItemFactory itemFactory = new ItemFactory();
        InventoryFactory inventoryFactory = new InventoryFactory();
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();
        IHeroManager heroManager = new HeroManager(itemFactory, inventoryFactory);
        ICommandInterpreter commandInterpreter = new CommandInterpreter(heroManager);

        IEngine engine = new Engine(reader, writer, commandInterpreter);
        engine.Run();
    }
}