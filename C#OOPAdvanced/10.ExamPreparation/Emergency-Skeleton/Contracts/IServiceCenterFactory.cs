namespace Emergency_Skeleton.Contracts
{
    using System.Collections.Generic;

    public interface IServiceCenterFactory
    {
        IEmergencyCenter Create(List<string> args);
    }
}