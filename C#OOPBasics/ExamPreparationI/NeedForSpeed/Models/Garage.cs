using System.Collections.Generic;
public class Garage
{
    private Dictionary<int, Car> parkedCars;

    public Garage()
    {
        this.ParkedCars = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> ParkedCars
    {
        get { return parkedCars; }
        set { parkedCars = value; }
    }
}
