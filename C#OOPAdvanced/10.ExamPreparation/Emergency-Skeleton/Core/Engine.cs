namespace Emergency_Skeleton.Core
{
    using Emergency_Skeleton.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private IEmergencyManagementSystem manager;
        private IReader reader;
        private IWriter writer;

        public Engine(IEmergencyManagementSystem manager, IReader reader, IWriter writer)
        {
            this.manager = manager;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var input = this.reader.ReadLine();

            while (input != "EmergencyBreak")
            {
                var cmdArgs = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = cmdArgs[0];
                var result = string.Empty;

                switch (command)
                {
                    case "RegisterPropertyEmergency":
                        result = this.manager.RegisterPropertyEmergency(cmdArgs);
                        break;

                    case "RegisterHealthEmergency":
                        result = this.manager.RegisterHealthEmergency(cmdArgs);
                        break;

                    case "RegisterOrderEmergency":
                        result = this.manager.RegisterOrderEmergency(cmdArgs);
                        break;

                    case "RegisterFireServiceCenter":
                        result = this.manager.RegisterFireServiceCenter(cmdArgs);
                        break;

                    case "RegisterMedicalServiceCenter":
                        result = this.manager.RegisterMedicalServiceCenter(cmdArgs);
                        break;

                    case "RegisterPoliceServiceCenter":
                        result = this.manager.RegisterPoliceServiceCenter(cmdArgs);
                        break;

                    case "ProcessEmergencies":
                        result = this.manager.ProcessEmergencies(cmdArgs);
                        break;

                    case "EmergencyReport":
                        result = this.manager.EmergencyReport();
                        break;
                }

                this.writer.WriteLine(result);

                input = this.reader.ReadLine();
            }
        }
    }
}