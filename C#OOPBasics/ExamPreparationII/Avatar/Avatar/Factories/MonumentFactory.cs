using System.Collections.Generic;

public class MonumentFactory
{
    public Monument Create(List<string> monumentArgs)
    {
        var type = monumentArgs[1];
        var name = monumentArgs[2];
        var affinity = int.Parse(monumentArgs[3]);

        switch (type)
        {
            case "Fire":
                return new FireMonument(name,affinity);
            case "Water":
                return new WaterMonument(name, affinity);
            case "Earth":
                return new EarthMonument(name, affinity);
            case "Air":
                return new AirMonument(name, affinity);
            default:
                return null;
        }
    }
}
