using NUnit.Framework;
using System;

[TestFixture]
public class HeroInventoryTests
{
    [Test]
    public void TwoItemsWithSameNameThrowException()
    {
        var heroInventory = new HeroInventory();
        var item1 = new CommonItem("Sword", 10, 10, 10, 10, 10);
        var item2 = new CommonItem("Sword", 10, 10, 10, 10, 10);

        heroInventory.AddCommonItem(item1);

        Assert.Throws<ArgumentException>(() => heroInventory.AddCommonItem(item2));
    }

    [Test]
    public void TestAgilityBonus()
    {
        var heroInventory = new HeroInventory();
        var item1 = new CommonItem("Sword", 10, 10, 10, 10, 10);

        heroInventory.AddCommonItem(item1);

        Assert.AreEqual(10, heroInventory.TotalAgilityBonus);
    }

    [Test]
    public void TestDamageBonus()
    {
        var heroInventory = new HeroInventory();
        var item1 = new CommonItem("Sword", 10, 10, 10, 10, 10);

        heroInventory.AddCommonItem(item1);

        Assert.AreEqual(10, heroInventory.TotalDamageBonus);
    }

    [Test]
    public void TestInteligenceBonus()
    {
        var heroInventory = new HeroInventory();
        var item1 = new CommonItem("Sword", 10, 10, 10, 10, 10);

        heroInventory.AddCommonItem(item1);

        Assert.AreEqual(10, heroInventory.TotalIntelligenceBonus);
    }

    [Test]
    public void TestStrenghtBonus()
    {
        var heroInventory = new HeroInventory();
        var item1 = new CommonItem("Sword", 10, 10, 10, 10, 10);

        heroInventory.AddCommonItem(item1);

        Assert.AreEqual(10, heroInventory.TotalStrengthBonus);
    }

    [Test]
    public void TestHitPointsBonus()
    {
        var heroInventory = new HeroInventory();
        var item1 = new CommonItem("Sword", 10, 10, 10, 10, 10);

        heroInventory.AddCommonItem(item1);

        Assert.AreEqual(10, heroInventory.TotalHitPointsBonus);
    }

    [Test]
    public void TotalStatsBonus()
    {
        var heroInventory = new HeroInventory();
        var item1 = new CommonItem("Sword", 10, 10, 10, 10, 10);

        heroInventory.AddCommonItem(item1);

        long totalStatsBonus = heroInventory.TotalAgilityBonus +
                               heroInventory.TotalDamageBonus +
                               heroInventory.TotalHitPointsBonus +
                               heroInventory.TotalIntelligenceBonus +
                               heroInventory.TotalStrengthBonus;

        Assert.AreEqual(50, totalStatsBonus);
    }

    [Test]
    public void NewInventoryStatsAreZero()
    {
        var heroInventory = new HeroInventory();

        long totalStatsBonus = heroInventory.TotalAgilityBonus
                               + heroInventory.TotalStrengthBonus
                               + heroInventory.TotalIntelligenceBonus
                               + heroInventory.TotalHitPointsBonus
                               + heroInventory.TotalDamageBonus;

        Assert.AreEqual(0, totalStatsBonus);
    }

    [Test]
    public void GetBonusFromCommonItem()
    {
        IItem item = new CommonItem("TestItem", 1, 1, 1, 1, 1);
        var heroInventory = new HeroInventory();

        heroInventory.AddCommonItem(item);

        Assert.AreEqual(1, heroInventory.TotalAgilityBonus);
        Assert.AreEqual(1, heroInventory.TotalDamageBonus);
        Assert.AreEqual(1, heroInventory.TotalHitPointsBonus);
        Assert.AreEqual(1, heroInventory.TotalIntelligenceBonus);
        Assert.AreEqual(1, heroInventory.TotalStrengthBonus);
    }

    [Test]
    public void CreatingNewHeroInventoryIsSuccessful()
    {
        var heroInventory = new HeroInventory();

        Assert.Pass();
    }

    [Test]
    public void AddCommonItemIsSuccessful()
    {
        IItem item = new CommonItem("Axe", 10, 10, 10, 10, 10);
        var heroInventory = new HeroInventory();

        heroInventory.AddCommonItem(item);

        Assert.Pass();
    }

    [Test]
    public void AddCommonItemChangesStats()
    {
        IItem item = new CommonItem("Axe", 10, 10, 10, 10, 10);
        var heroInventory = new HeroInventory();

        heroInventory.AddCommonItem(item);
        long totalStatsBonus = heroInventory.TotalAgilityBonus
                               + heroInventory.TotalStrengthBonus
                               + heroInventory.TotalIntelligenceBonus
                               + heroInventory.TotalHitPointsBonus
                               + heroInventory.TotalDamageBonus;

        Assert.AreEqual(50, totalStatsBonus);
    }

    [Test]
    public void AddCommonItemChangesDamage()
    {
        IItem item = new CommonItem("Axe", 10, 10, 10, 10, 10);
        var heroInventory = new HeroInventory();

        heroInventory.AddCommonItem(item);

        Assert.AreEqual(10, heroInventory.TotalDamageBonus);
    }

    [Test]
    public void AddCommonItemChangesHp()
    {
        IItem item = new CommonItem("Axe", 10, 10, 10, 10, 10);
        var heroInventory = new HeroInventory();

        heroInventory.AddCommonItem(item);

        Assert.AreEqual(10, heroInventory.TotalHitPointsBonus);
    }

    [Test]
    public void RecipeCompletionChangesStats()
    {
        string[] recipeComponents = new string[] { "Axe", "Shield" };
        IRecipe recipe = new Recipe("MegaWeapon", 100, 100, 100, 100, 100, recipeComponents);
        IItem axe = new CommonItem("Axe", 10, 10, 10, 10, 10);
        IItem shield = new CommonItem("Shield", 20, 20, 20, 20, 20);
        var heroInventory = new HeroInventory();

        heroInventory.AddCommonItem(axe);
        heroInventory.AddCommonItem(shield);
        heroInventory.AddRecipeItem(recipe);
        long totalStatsBonus = heroInventory.TotalAgilityBonus
                               + heroInventory.TotalStrengthBonus
                               + heroInventory.TotalIntelligenceBonus
                               + heroInventory.TotalHitPointsBonus
                               + heroInventory.TotalDamageBonus;

        Assert.AreEqual(500, totalStatsBonus);
    }

    [Test]
    public void AddingNullItemThrowsException()
    {
        IItem item = null;
        var heroInventory = new HeroInventory();

        Assert.Throws<NullReferenceException>(() => heroInventory.AddCommonItem(item));
    }

    [Test]
    public void AddingNullRecipeThrowsException()
    {
        IRecipe recipe = null;
        var heroInventory = new HeroInventory();

        Assert.Throws<NullReferenceException>(() => heroInventory.AddRecipeItem(recipe));
    }
}