using System.Collections.Generic;

namespace _08.RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;

        public Car(string model)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = new List<Tire>();
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return this.engine;
            }

            set
            {
                this.engine = value;
            }
        }

        public Cargo Cargo
        {
            get
            {
                return this.cargo;
            }

            set
            {
                this.cargo = value;
            }
        }

        public List<Tire> Tires
        {
            get
            {
                return this.tires;
            }

            set
            {
                this.tires = value;
            }
        }
    }
}