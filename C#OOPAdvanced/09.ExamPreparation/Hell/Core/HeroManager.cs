using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IHeroManager
{
    private readonly ItemFactory itemFactory;
    private readonly InventoryFactory inventoryFactory;
    private readonly IDictionary<string, AbstractHero> heroes;

    public HeroManager(ItemFactory itemFactory, InventoryFactory inventoryFactory)
    {
        this.itemFactory = itemFactory;
        this.heroes = new Dictionary<string, AbstractHero>();
        this.inventoryFactory = inventoryFactory;
    }

    public string AddHero(IList<string> arguments)
    {
        string result = string.Empty;
        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type typeHero = Type.GetType(heroType);
            var constructors = typeHero.GetConstructors();
            var inventoryFactory = this.inventoryFactory.Create();
            AbstractHero hero = (AbstractHero)constructors[0].Invoke(new object[] { heroName, inventoryFactory });
            this.heroes[heroName] = hero;

            result = string.Format($"Created {heroType} - {hero.Name}");
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(IList<string> arguments)
    {
        string result = string.Empty;
        string heroName = arguments[1];

        IItem newItem = itemFactory.Create(arguments);
        this.heroes[heroName].Inventory.AddCommonItem(newItem);

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string AddRecipeToHero(IList<string> arguments)
    {
        var recipeName = arguments[0];
        var heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);
        var neededItems = arguments.Skip(7).ToList();

        IRecipe recipe = new Recipe(recipeName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, neededItems);

        this.heroes[heroName].AddRecipe(recipe);

        return string.Format(Constants.RecipeCreatedMessage, recipeName, heroName);
    }

    public string PrintAllHeroes()
    {
        var sb = new StringBuilder();
        var counter = 1;
        var heroesToPrint = new SortedSet<AbstractHero>(this.heroes.Values);
        foreach (var hero in heroesToPrint)
        {
            List<string> itemsByName = new List<string>();
            foreach (var heroItem in hero.Items)
            {
                itemsByName.Add(heroItem.Name);
            }

            sb.AppendLine($"{counter++}. {hero.GetType().Name}: {hero.Name}");
            sb.AppendLine($"###HitPoints: {hero.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Damage}");
            sb.AppendLine($"###Strength: {hero.Strength}");
            sb.AppendLine($"###Agility: {hero.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Intelligence}");
            if (itemsByName.Any())
            {
                sb.AppendLine($"###Items: {string.Join(", ", itemsByName)}");
            }
            else
            {
                sb.AppendLine($"###Items: None");
            }
        }

        return sb.ToString().Trim();
    }

    public string Inspect(IList<string> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }
}