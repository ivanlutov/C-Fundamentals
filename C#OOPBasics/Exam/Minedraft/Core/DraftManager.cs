using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private double totalMinedOre;
    private double totalEnergyStored;
    private string mode;

    public DraftManager()
    {
        harvesterFactory = new HarvesterFactory();
        providerFactory = new ProviderFactory();
        harvesters = new Dictionary<string, Harvester>();
        providers = new Dictionary<string, Provider>();
        this.totalMinedOre = 0;
        this.totalEnergyStored = 0;
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var msg = string.Empty;

        try
        {
            var type = arguments[0];
            var id = arguments[1];
            var harvester = harvesterFactory.Create(arguments);
            msg = $"Successfully registered {type} Harvester - {id}";
            harvesters[id] = harvester;
        }
        catch (ArgumentException ae)
        {
            msg = ae.Message;
        }

        return msg;
    }

    public string RegisterProvider(List<string> arguments)
    {
        var msg = string.Empty;

        try
        {
            var type = arguments[0];
            var id = arguments[1];
            var provider = providerFactory.Create(arguments);
            msg = $"Successfully registered {type} Provider - {id}";
            providers[id] = provider;
        }
        catch (ArgumentException ae)
        {
            msg = ae.Message;
        }

        return msg;
    }

    public string Day()
    {
        double dayEnergy = 0;
        double dayOre = 0;
        double harvestNeededEnergyForDay = 0;

        totalEnergyStored += providers.Sum(v => v.Value.EnergyOutput);
        dayEnergy = providers.Sum(v => v.Value.EnergyOutput);

        harvestNeededEnergyForDay += harvesters.Sum(h => h.Value.EnergyRequirement);

        if (totalEnergyStored >= harvestNeededEnergyForDay)
        {
            if (mode == "Full")
            {
                dayOre += harvesters.Values.Sum(h => h.OreOutput);
                totalEnergyStored -= harvestNeededEnergyForDay;
            }
            else if (mode == "Half")
            {
                dayOre += harvesters.Values.Sum(h => (h.OreOutput * 50) / 100);
                totalEnergyStored -= (harvestNeededEnergyForDay * 60) / 100;
            }

            totalMinedOre += dayOre;
        }

        var sb = new StringBuilder();
        sb.AppendLine($"A day has passed.");
        sb.AppendLine($"Energy Provided: {dayEnergy}");
        sb.AppendLine($"Plumbus Ore Mined: {dayOre}");

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var modeCommand = arguments[0];

        if (modeCommand == "Energy")
        {
            mode = "Energy";
        }
        else if (modeCommand == "Full")
        {
            mode = "Full";
        }
        else if (modeCommand == "Half")
        {
            mode = "Half";
        }

        return $"Successfully changed working mode to {modeCommand} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var msg = string.Empty;

        if (providers.ContainsKey(id))
        {
            msg = providers[id].ToString();
        }
        if (harvesters.ContainsKey(id))
        {
            msg = harvesters[id].ToString();
        }

        if (msg != string.Empty)
        {
            return msg;
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();

        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalEnergyStored}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return sb.ToString().Trim();
    }
}