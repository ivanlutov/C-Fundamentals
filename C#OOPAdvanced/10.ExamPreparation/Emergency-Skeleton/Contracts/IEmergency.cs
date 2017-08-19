namespace Emergency_Skeleton.Contracts
{
    using Emergency_Skeleton.Enums;

    public interface IEmergency
    {
        string Description { get; }

        EmergencyLevel Level { get; }

        IRegistrationTime Time { get; }

        int GetInfo();
    }
}