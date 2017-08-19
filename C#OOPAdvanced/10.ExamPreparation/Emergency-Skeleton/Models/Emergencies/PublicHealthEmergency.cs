namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Contracts;
    using Emergency_Skeleton.Enums;

    public class PublicHealthEmergency : BaseEmergency
    {
        public PublicHealthEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, int numberOfCasualties)
            : base(description, emergencyLevel, registrationTime)
        {
            this.NumberOfCasualties = numberOfCasualties;
        }

        public int NumberOfCasualties { get; set; }

        public override int GetInfo()
        {
            return NumberOfCasualties;
        }
    }
}