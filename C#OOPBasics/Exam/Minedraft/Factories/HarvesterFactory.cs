using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester Create(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequerement = double.Parse(arguments[3]);

        Harvester harvester = null;
        if (type == "Sonic")
        {
            var sonicFactor = int.Parse(arguments[4]);
            harvester = new SonicHarvester(id, oreOutput, energyRequerement, sonicFactor);
        }
        else if (type == "Hammer")
        {
            harvester = new HammerHarvester(id, oreOutput, energyRequerement);
        }

        return harvester;
    }
}