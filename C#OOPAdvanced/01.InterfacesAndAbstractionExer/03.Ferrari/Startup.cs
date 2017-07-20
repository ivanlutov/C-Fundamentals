using System;
public class Startup
{
    public static void Main()
    {
        var driverName = Console.ReadLine();
        var car = new Ferrari(driverName);
        Console.WriteLine(car);
    }
}

