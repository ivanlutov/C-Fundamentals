namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Contracts;
    using Emergency_Skeleton.Enums;

    public class PublicOrderEmergency : BaseEmergency
    {
        public PublicOrderEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, string status)
            : base(description, emergencyLevel, registrationTime)
        {
            this.Status = status;
        }

        public string Status { get; set; }

        public override int GetInfo()
        {
            if (this.Status == "Special")
            {
                return 1;
            }

            return 0;
        }
    }
}