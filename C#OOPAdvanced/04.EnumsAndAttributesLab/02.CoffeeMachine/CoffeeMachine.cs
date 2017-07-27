using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private int allMoney;
    private readonly IList<CoffeeType> coffeesSold;

    public CoffeeMachine()
    {
        this.coffeesSold = new List<CoffeeType>();
        this.allMoney = 0;
    }

    public IEnumerable<CoffeeType> CoffeesSold
    {
        get { return this.coffeesSold; }
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeePrice coffeePrice = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);
        var intCoffePrice = (int)coffeePrice;
        CoffeeType coffeeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);

        if (allMoney >= intCoffePrice)
        {
            coffeesSold.Add(coffeeType);
            allMoney = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        Coin coinType = (Coin)Enum.Parse(typeof(Coin), coin);
        this.allMoney += (int)coinType;
    }
}