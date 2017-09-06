public class Startup
{
    public static void Main()
    {
        //    var carFactory = new CarFactory();
        //    var tyreFactory = new TyreFactory();
        //    var driverFactory = new DriverFactory();
        var raceTower = new RaceTower();
        var engine = new Engine(raceTower);
        engine.Start();
    }
}