using System.Collections.Generic;
using System.Linq;

public class WeaponManager
{
    private List<Weapon> weapons;
    WeaponFactory weaponFactory;
    GemFactory gemFactory;
    public WeaponManager()
    {
        this.weapons = new List<Weapon>();
        this.weaponFactory = new WeaponFactory();
        this.gemFactory = new GemFactory();
    }

    public void Create(List<string> tokens)
    {
        Weapon weapon = weaponFactory.Create(tokens);
        weapons.Add(weapon);
    }

    public void Add(List<string> tokens)
    {
        var weaponName = tokens[0];
        var index = int.Parse(tokens[1]);
        var gemArguments = tokens[2];
        Gem gem = gemFactory.Create(gemArguments);
        var currentWeapon = weapons.FirstOrDefault(w => w.Name == weaponName);
        currentWeapon.AddGem(index, gem);
    }

    public void Remove(List<string> tokens)
    {
        var weaponName = tokens[0];
        var index = int.Parse(tokens[1]);
        var currentWeapon = weapons.FirstOrDefault(w => w.Name == weaponName);
        currentWeapon.RemoveGem(index);
    }

    public string Print(string name)
    {
        var printWeapon = weapons.FirstOrDefault(w => w.Name == name);
        printWeapon.CalculateStats();
        return $"{printWeapon.ToString()}";
    }
}
