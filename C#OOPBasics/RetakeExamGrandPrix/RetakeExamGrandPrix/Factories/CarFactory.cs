using System.Collections.Generic;

public class CarFactory
{
    public Car Create(List<string> args, Tyre tyre)
    {
        var hp = int.Parse(args[0]);
        var fuelAmount = double.Parse(args[1]);

        return new Car(hp, fuelAmount, tyre);
    }
}

