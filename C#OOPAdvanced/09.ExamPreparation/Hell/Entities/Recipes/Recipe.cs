using System.Collections.Generic;

public class Recipe : IRecipe
{
    public Recipe(string recipeItemName, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus, IList<string> items)
    {
        this.RecipeItemName = recipeItemName;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
        this.RequiredItems = new List<string>(items);
    }

    public IList<string> RequiredItems { get; set; }
    public string RecipeItemName { get; set; }
    public int StrengthBonus { get; set; }
    public int AgilityBonus { get; set; }
    public int IntelligenceBonus { get; set; }
    public int HitPointsBonus { get; set; }
    public int DamageBonus { get; set; }
}