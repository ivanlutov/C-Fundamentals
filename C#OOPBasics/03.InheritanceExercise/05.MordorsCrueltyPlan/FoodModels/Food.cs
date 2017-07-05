using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.MordorsCrueltyPlan.FoodModels
{
    public abstract class Food
    {
        private int pointOfHappines;

        protected Food(int pointOfHappines)
        {
            this.PointOfHappines = pointOfHappines;
        }
        public virtual int PointOfHappines
        {
            get { return pointOfHappines; }
            set { pointOfHappines = value; }
        }
    }
}
