using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.MordorsCrueltyPlan.MoodModels
{
    public abstract class Mood
    {
        public override string ToString()
        {
            return $"{GetType().Name}";
        }
    }
}
