namespace Emergency_Skeleton.Models.EmergenciesCenters
{
    using Emergency_Skeleton.Contracts;
    using System.Collections.Generic;

    public abstract class BaseEmergencyCenter : IEmergencyCenter
    {
        private string name;
        private int amountOfMaximumEmergencies;

        protected BaseEmergencyCenter(string name, int amountOfMaximumEmergencies)
        {
            this.Name = name;
            this.amountOfMaximumEmergencies = amountOfMaximumEmergencies;
            this.Emergencies = new List<IEmergency>();
        }

        public IList<IEmergency> Emergencies { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int AmountOfMaximumEmergencies
        {
            get
            {
                return this.amountOfMaximumEmergencies;
            }
            set
            {
                this.amountOfMaximumEmergencies = value;
            }
        }

        public bool isForRetirement()
        {
            if (this.AmountOfMaximumEmergencies > this.Emergencies.Count)
            {
                return true;
            }

            return false;
        }
    }
}