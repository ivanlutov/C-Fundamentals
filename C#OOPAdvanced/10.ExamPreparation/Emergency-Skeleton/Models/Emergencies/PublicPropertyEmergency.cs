namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Contracts;
    using Emergency_Skeleton.Enums;

    public class PublicPropertyEmergency : BaseEmergency
    {
        public PublicPropertyEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, int damage)
            : base(description, emergencyLevel, registrationTime)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }

        public override int GetInfo()
        {
            return this.Damage;
        }
    }
}