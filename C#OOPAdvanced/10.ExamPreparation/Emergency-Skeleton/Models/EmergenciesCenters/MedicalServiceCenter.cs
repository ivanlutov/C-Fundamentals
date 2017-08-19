namespace Emergency_Skeleton.Models.EmergenciesCenters
{
    public class MedicalServiceCenter : BaseEmergencyCenter
    {
        public MedicalServiceCenter(string name, int amountOfMaximumEmergencies)
            : base(name, amountOfMaximumEmergencies)
        {
        }
    }
}