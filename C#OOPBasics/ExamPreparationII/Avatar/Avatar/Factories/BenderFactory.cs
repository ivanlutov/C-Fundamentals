using System.Collections.Generic;

public class BenderFactory 
{
    public Bender Create(List<string> benderArgs)
    {
        var type = benderArgs[1];
        var name = benderArgs[2];
        var power = int.Parse(benderArgs[3]);
        var secondaryParameter = double.Parse(benderArgs[4]);

        switch (type)
        {
            case "Fire":
                return new FireBender(name, power, secondaryParameter);
            case "Water":
                return new WaterBender(name, power, secondaryParameter);
            case "Earth":
                return new EarthBender(name, power, secondaryParameter);
            case "Air":
               return new AirBender(name, power, secondaryParameter);
            default:
                return null;
        }
    }
}

