using System.Collections.Generic;

namespace NeedForSpeed.Models
{
    public abstract class Race
    {
        private int id;
        private int length;
        private string route;
        private int prizePool;
        public List<Car> participants;

        protected Race(int id,int length, string route, int prizePool)
        {
            this.ID = id;
            this.Length = length;
            this.Route = route;
            this.PrizePool = prizePool;
            this.participants = new List<Car>();
        }
        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public string Route
        {
            get { return route; }
            set { route = value; }
        }

        public int PrizePool
        {
            get { return prizePool; }
            set { prizePool = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}