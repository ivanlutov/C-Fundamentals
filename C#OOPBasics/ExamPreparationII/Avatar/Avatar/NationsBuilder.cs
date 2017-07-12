using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class NationsBuilder
{
    private static int counter = 1;

    Nation airNation = new AirNation();
    Nation fireNation = new FireNation();
    Nation waterNation = new WaterNation();
    Nation earthNation = new EarthNation();
    BenderFactory benderFactory = new BenderFactory();
    MonumentFactory monumentFactory = new MonumentFactory();
    List<string> wars = new List<string>();
    public void AssignBender(List<string> benderArgs)
    {
        Bender currentBender = benderFactory.Create(benderArgs);
        var type = benderArgs[1];

        switch (type)
        {
            case "Fire":
                fireNation.Benders.Add(currentBender);
                break;
            case "Water":
                waterNation.Benders.Add(currentBender);
                break;
            case "Earth":
                earthNation.Benders.Add(currentBender);
                break;
            case "Air":
                airNation.Benders.Add(currentBender);
                break;
        }
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        Monument currentMonument = monumentFactory.Create(monumentArgs);
        var type = monumentArgs[1];

        switch (type)
        {
            case "Fire":
                fireNation.Monuments.Add(currentMonument);
                break;
            case "Water":
                waterNation.Monuments.Add(currentMonument);
                break;
            case "Earth":
                earthNation.Monuments.Add(currentMonument);
                break;
            case "Air":
                airNation.Monuments.Add(currentMonument);
                break;
        }

    }
    public string GetStatus(string nationsType)
    {
        var result = string.Empty;
        switch (nationsType)
        {
            case "Fire":
                result = fireNation.ToString();
                break;
            case "Water":
                result = waterNation.ToString();
                break;
            case "Earth":
                result = earthNation.ToString();
                break;
            case "Air":
                result = airNation.ToString();
                break;
        }

        return result;
    }
    public void IssueWar(string nationsType)
    {
        wars.Add($"War {counter++} issued by {nationsType}");

        var airPower = airNation.GetTotalPower();
        var firePower = fireNation.GetTotalPower();
        var waterPower = waterNation.GetTotalPower();
        var earthPower = earthNation.GetTotalPower();

        var nationDict = new Dictionary<Nation, double>();
        nationDict.Add(airNation, airPower);
        nationDict.Add(fireNation, firePower);
        nationDict.Add(waterNation, waterPower);
        nationDict.Add(earthNation, earthPower);

        nationDict = nationDict.OrderByDescending(k => k.Value).Skip(1).ToDictionary(k => k.Key, v => v.Value);
        
        foreach (var nation in nationDict)
        {
            nation.Key.Benders.Clear();
            nation.Key.Monuments.Clear();
        }

        nationDict.Clear();
    }
    public string GetWarsRecord()
    {
        var sb = new StringBuilder();

        for (int i = 0; i < wars.Count; i++)
        {
            sb.AppendLine(wars[i]);
        }

        return sb.ToString().Trim();
    }
}

