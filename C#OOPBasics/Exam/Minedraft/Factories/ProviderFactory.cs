using System.Collections.Generic;

public class ProviderFactory
{
    public Provider Create(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        Provider provider = null;
        if (type == "Solar")
        {
            provider = new SolarProvider(id, energyOutput);
        }
        else if (type == "Pressure")
        {
            provider = new PressureProvider(id, energyOutput);
        }

        return provider;
    }
}