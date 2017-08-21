public class LastArmyMain
{
    public static void Main()
    {
        IWriter writer = new ConsoleWriter();
        IReader reader = new ConsoleReader();
        IArmy army = new Army();
        IAmmunitionFactory amunitionFactory = new AmmunitionFactory();
        IMissionFactory missionFactory = new MissionFactory();
        ISoldierFactory soldierFactory = new SoldierFactory();
        IWareHouse wareHouse = new WareHouse(amunitionFactory);
        IMissionController missionController = new MissionController(army, wareHouse);
        IGameController gameController = new GameController(missionController, soldierFactory, missionFactory, writer, wareHouse, army);
        IEngine engine = new Engine(reader, writer, missionController, gameController
            , army, wareHouse, soldierFactory, missionFactory, amunitionFactory);

        engine.Run();
    }
}