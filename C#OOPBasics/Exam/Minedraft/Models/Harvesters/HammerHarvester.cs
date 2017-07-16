public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput += (this.OreOutput * 200) / 100;
        this.EnergyRequirement *= 2;
    }
}
