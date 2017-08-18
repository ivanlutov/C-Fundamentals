public interface IItem
{
    string Name { get; set; }
    int StrengthBonus { get; set; }
    int AgilityBonus { get; set; }
    int IntelligenceBonus { get; set; }
    int HitPointsBonus { get; set; }
    int DamageBonus { get; set; }
}