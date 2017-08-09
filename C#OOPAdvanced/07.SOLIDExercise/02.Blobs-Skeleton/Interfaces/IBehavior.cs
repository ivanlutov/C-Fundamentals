using _02.Blobs.Entities;

namespace _02.Blobs.Interfaces
{
    public interface IBehavior
    {
        //public Behavior()
        //{
        //    this.ToDelayRecurrentEffect = true;
        //}

        bool IsTriggered { get; set; }

        bool ToDelayRecurrentEffect { get; set; }

        void Trigger(Blob source);

        void ApplyRecurrentEffect(Blob source);

        void ApplyTriggerEffect(Blob source);
    }
}