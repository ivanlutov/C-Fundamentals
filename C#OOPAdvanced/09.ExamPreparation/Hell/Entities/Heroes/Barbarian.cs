public class Barbarian : AbstractHero
{
    private const int StrengthPointsCreate = 90;
    private const int AgilityPointsCreate = 25;
    private const int IntelligencePointsCreate = 10;
    private const int HitPointsCreate = 350;
    private const int DamagePointsCreate = 150;

    public Barbarian(string name, IInventory inventoty) 
        : base(name, StrengthPointsCreate, AgilityPointsCreate, IntelligencePointsCreate, HitPointsCreate, DamagePointsCreate, inventoty)
    {
    }
}
