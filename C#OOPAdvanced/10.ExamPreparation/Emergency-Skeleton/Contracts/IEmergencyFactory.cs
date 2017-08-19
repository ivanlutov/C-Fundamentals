namespace Emergency_Skeleton.Contracts
{
    using System.Collections.Generic;

    public interface IEmergencyFactory
    {
        IEmergency Create(List<string> args);
    }
}