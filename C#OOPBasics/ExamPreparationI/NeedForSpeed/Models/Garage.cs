using System.Collections.Generic;

namespace NeedForSpeed.Models
{
    public class Garage
    {
        public List<Car> parkedCars;
        public Garage()
        {
            this.parkedCars = new List<Car>();
        }
       
    }
}