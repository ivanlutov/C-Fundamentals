namespace Emergency_Skeleton
{
    using Emergency_Skeleton.Contracts;
    using Emergency_Skeleton.Core;
    using Emergency_Skeleton.Factories;
    using Emergency_Skeleton.Models.Readers;
    using Emergency_Skeleton.Models.Writers;

    public class Startup
    {
        public static void Main()
        {
            IEmergencyFactory emergencyFactory = new EmergencyFactory();
            IServiceCenterFactory centerFactory = new ServiceCenterFactory();
            IEmergencyManagementSystem manager = new EmergencyManagementSystem(emergencyFactory, centerFactory);
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            IEngine engine = new Engine(manager, reader, writer);
            engine.Run();
        }
    }
}