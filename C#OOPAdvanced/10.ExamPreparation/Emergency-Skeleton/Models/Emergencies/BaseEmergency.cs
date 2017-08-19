namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Contracts;
    using Emergency_Skeleton.Enums;

    public abstract class BaseEmergency : IEmergency
    {
        private string description;

        private EmergencyLevel emergencyLevel;

        private IRegistrationTime registrationTime;

        protected BaseEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime)
        {
            this.Description = description;
            this.Level = emergencyLevel;
            this.Time = registrationTime;
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public EmergencyLevel Level
        {
            get { return this.emergencyLevel; }
            set { this.emergencyLevel = value; }
        }

        public IRegistrationTime Time
        {
            get { return this.registrationTime; }
            set { this.registrationTime = value; }
        }

        public abstract int GetInfo();
    }
}