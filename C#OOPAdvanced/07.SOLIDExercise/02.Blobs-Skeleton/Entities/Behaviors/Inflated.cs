using _02.Blobs.Interfaces;

namespace _02.Blobs.Entities.Behaviors
{
    public class Inflated : IBehavior
    {
        public bool IsTriggered { get; set; }

        public bool ToDelayRecurrentEffect { get; set; }

        public void ApplyTriggerEffect(Blob source)
        {
            source.Health += 50;
            this.ToDelayRecurrentEffect = true;
        }

        public void ApplyRecurrentEffect(Blob source)
        {
            source.Health -= 10;
        }
        public void Trigger(Blob source)
        {

        }
    }
}