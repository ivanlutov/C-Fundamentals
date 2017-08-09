using _02.Blobs.Interfaces;

namespace _02.Blobs.Entities.Behaviors
{
    public class Aggressive : IBehavior
    {
        private static int AggressiveDamageMultiplier = 2;
        private static int AggressiveDamageDecrementer = 5;

        private int sourceInitialDamage;

        public bool IsTriggered { get; set; }
        public bool ToDelayRecurrentEffect { get; set; }

        public void ApplyTriggerEffect(Blob source)
        {
            source.Damage *= AggressiveDamageMultiplier;
            this.ToDelayRecurrentEffect = true;
        }

        public  void Trigger(Blob source)
        {
            this.sourceInitialDamage = source.Damage;
            this.IsTriggered = true;
            this.ApplyTriggerEffect(source);
        }

        public  void ApplyRecurrentEffect(Blob source)
        {
            if (this.ToDelayRecurrentEffect)
            {
               this.ToDelayRecurrentEffect = false;
            }
            else
            {
                source.Damage -= AggressiveDamageDecrementer;

                if (source.Damage <= this.sourceInitialDamage)
                {
                    source.Damage = this.sourceInitialDamage;
                }
            }
        }
    }
}