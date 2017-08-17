using System.Text;

public abstract class Item : IItem
{
    protected Item(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
    }
    public string Name { get; set; }
    public int StrengthBonus { get; set; }
    public int AgilityBonus { get; set; }
    public int IntelligenceBonus { get; set; }
    public int HitPointsBonus { get; set; }
    public int DamageBonus { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"###Item: {this.Name}");
        sb.AppendLine($"###+25 {this.StrengthBonus}");
        sb.AppendLine($"###+10 {this.AgilityBonus}");
        sb.AppendLine($"###+10 {this.IntelligenceBonus}");
        sb.AppendLine($"###+100 {this.HitPointsBonus}");
        sb.AppendLine($"###+50 {this.DamageBonus}");

        return sb.ToString().Trim();
    }
}
