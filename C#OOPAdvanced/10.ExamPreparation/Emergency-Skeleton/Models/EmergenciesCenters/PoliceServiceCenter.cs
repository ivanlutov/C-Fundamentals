namespace Emergency_Skeleton.Models.EmergenciesCenters
{
    public class PoliceServiceCenter : BaseEmergencyCenter
    {
        public PoliceServiceCenter(string name, int amountOfMaximumEmergencies)
            : base(name, amountOfMaximumEmergencies)
        {
        }
    }
}