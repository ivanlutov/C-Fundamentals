namespace Emergency_Skeleton.Contracts
{
    using System.Collections.Generic;

    public interface IEmergencyManagementSystem
    {
        string RegisterPropertyEmergency(List<string> args);

        string RegisterHealthEmergency(List<string> args);

        string RegisterOrderEmergency(List<string> args);

        string RegisterFireServiceCenter(List<string> args);

        string RegisterMedicalServiceCenter(List<string> args);

        string RegisterPoliceServiceCenter(List<string> args);

        string ProcessEmergencies(List<string> args);

        string EmergencyReport();
    }
}