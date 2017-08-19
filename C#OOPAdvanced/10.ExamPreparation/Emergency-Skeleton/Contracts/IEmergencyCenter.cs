namespace Emergency_Skeleton.Contracts
{
    using System.Collections.Generic;

    public interface IEmergencyCenter
    {
        IList<IEmergency> Emergencies { get; set; }

        string Name { get; set; }

        int AmountOfMaximumEmergencies { get; set; }

        bool isForRetirement();
    }
}