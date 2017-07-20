using System;
public class Ferrari : ICar
{
    public Ferrari(string driver)
    {
        Model = "488-Spider";
        Driver = driver;
    }
    public string Model { get; set; }
    public string Driver { get; set; }
    public string UseBrake()
    {
        return "Brakes!";
    }
    public string PushGas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.UseBrake()}/{this.PushGas()}/{this.Driver}";
    }
}
