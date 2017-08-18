using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class AbstractHero : IHero, IComparable<AbstractHero>
{
    private readonly IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage, IInventory inventoty)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = inventoty;
    }

    public string Name { get; private set; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    public ICollection<IItem> Items
    {
        get
        {
            Type typeOfInventory = typeof(HeroInventory);
            FieldInfo[] fieldInfo = typeOfInventory
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo commonItemsStorage = fieldInfo.First(f => f.GetCustomAttributes<ItemAttribute>() != null);

            IDictionary<string, IItem> items = (IDictionary<string, IItem>)commonItemsStorage.GetValue(this.inventory);

            return items.Values;
        }
    }

    public IInventory Inventory
    {
        get { return this.inventory; }
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = other.PrimaryStats.CompareTo(this.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }

        return other.SecondaryStats.CompareTo(this.SecondaryStats);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Hero: {this.Name}, Class: {GetType().Name}");
        sb.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        sb.AppendLine($"Strength: {this.Strength}");
        sb.AppendLine($"Agility: {this.Agility}");
        sb.AppendLine($"Intelligence: {this.Intelligence}");
        if (this.Items.Count > 0)
        {
            sb.AppendLine($"Items:");
            foreach (var item in this.Items)
            {
                sb.AppendLine(item.ToString());
            }
        }
        else
        {
            sb.AppendLine($"Items: None");
        }

        return sb.ToString().Trim();
    }
}