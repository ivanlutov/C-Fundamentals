using System.Collections.Generic;

namespace NeedForSpeed.Models
{
    public class Garage
    {
        public Dictionary<int, Car> parkedCars;

        public Garage()
        {
            this.parkedCars = new Dictionary<int, Car>();
        }
    }
}