namespace Emergency_Skeleton.Models.EmergenciesCenters
{
    public class FireServiceCenter : BaseEmergencyCenter
    {
        public FireServiceCenter(string name, int amountOfMaximumEmergencies)
            : base(name, amountOfMaximumEmergencies)
        {
        }
    }
}