namespace Emergency_Skeleton.Core
{
    using Emergency_Skeleton.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EmergencyManagementSystem : IEmergencyManagementSystem
    {
        private IEmergencyFactory emergencyFactory;
        private IServiceCenterFactory centerFactory;
        private IList<IEmergency> emergencies;
        private IList<IEmergencyCenter> centers;
        private int countOfRegisteredEmergencies;
        private int currentlyRegisteredEmergencies;

        public EmergencyManagementSystem(IEmergencyFactory emergencyFactory, IServiceCenterFactory centerFactory)
        {
            this.emergencyFactory = emergencyFactory;
            this.centerFactory = centerFactory;
            this.emergencies = new List<IEmergency>();
            this.centers = new List<IEmergencyCenter>();
            this.countOfRegisteredEmergencies = 0;
            this.currentlyRegisteredEmergencies = 0;
        }

        public string RegisterPropertyEmergency(List<string> args)
        {
            var propertyEmergency = this.emergencyFactory.Create(args);
            this.emergencies.Add(propertyEmergency);
            this.countOfRegisteredEmergencies++;
            return $"Registered Public Property Emergency of level {propertyEmergency.Level} at {propertyEmergency.Time}.";
        }

        public string RegisterHealthEmergency(List<string> args)
        {
            var healthEmergency = this.emergencyFactory.Create(args);
            this.emergencies.Add(healthEmergency);
            this.countOfRegisteredEmergencies++;

            return $"Registered Public Health Emergency of level {healthEmergency.Level} at {healthEmergency.Time}.";
        }

        public string RegisterOrderEmergency(List<string> args)
        {
            var orderEmergency = this.emergencyFactory.Create(args);
            this.emergencies.Add(orderEmergency);
            this.countOfRegisteredEmergencies++;

            return $"Registered Public Order Emergency of level {orderEmergency.Level} at {orderEmergency.Time}.";
        }

        public string RegisterFireServiceCenter(List<string> args)
        {
            var fireCenter = this.centerFactory.Create(args);
            this.centers.Add(fireCenter);

            return $"Registered Fire Service Emergency Center - {args[1]}.";
        }

        public string RegisterMedicalServiceCenter(List<string> args)
        {
            var medicalCenter = this.centerFactory.Create(args);
            this.centers.Add(medicalCenter);

            return $"Registered Medical Service Emergency Center - {args[1]}.";
        }

        public string RegisterPoliceServiceCenter(List<string> args)
        {
            var policeCenter = this.centerFactory.Create(args);
            this.centers.Add(policeCenter);

            return $"Registered Police Service Emergency Center - {args[1]}.";
        }

        public string ProcessEmergencies(List<string> args)
        {
            var result = string.Empty;
            var registeredEmergencies = 0;
            var hasNotRegisteredEmergency = true;

            var typeOfEmergency = args[1];
            var centersTypeToSearch = string.Empty;
            if (typeOfEmergency == "Property")
            {
                centersTypeToSearch = "Fire";
            }
            else if (typeOfEmergency == "Health")
            {
                centersTypeToSearch = "Medical";
            }
            else if (typeOfEmergency == "Order")
            {
                centersTypeToSearch = "Police";
            }

            var allEmergencyOfThisType = this.emergencies.Where(e => e.GetType().Name.Contains(typeOfEmergency)).ToList();
            var allCentersOfThisType = this.centers.Where(c => c.GetType().Name.Contains(centersTypeToSearch)).ToList();

            foreach (var emergencyCenter in allCentersOfThisType)
            {
                foreach (var emergency in allEmergencyOfThisType)
                {
                    if (emergencyCenter.isForRetirement())
                    {
                        emergencyCenter.Emergencies.Add(emergency);
                        this.emergencies.Remove(emergency);
                        registeredEmergencies++;
                    }
                    else
                    {
                        hasNotRegisteredEmergency = false;
                    }
                }
            }

            if (hasNotRegisteredEmergency)
            {
                result = $"Successfully responded to all {typeOfEmergency} emergencies.";
                this.currentlyRegisteredEmergencies++;
            }
            else
            {
                result = $"{typeOfEmergency} Emergencies left to process: {allEmergencyOfThisType.Count - registeredEmergencies}.";
            }

            return result;
        }

        public string EmergencyReport()
        {
            var fireCenters = this.centers.Count(c => c.GetType().FullName.Contains("Fire") &&
                                                      c.Emergencies.Count < c.AmountOfMaximumEmergencies);

            var medicalCenters = this.centers.Count(c => c.GetType().FullName.Contains("Medical") &&
                                                         c.Emergencies.Count < c.AmountOfMaximumEmergencies);

            var policeCenters = this.centers.Count(c => c.GetType().FullName.Contains("Police") &&
                                                        c.Emergencies.Count < c.AmountOfMaximumEmergencies);

            var countOfDamageFixed = this.centers.Where(c => c.GetType().FullName.Contains("Fire"))
                .Sum(c => c.Emergencies.Sum(x => x.GetInfo()));

            var healthCasualtiesSaved = this.centers.Where(c => c.GetType().FullName.Contains("Medical"))
                .Sum(c => c.Emergencies.Sum(x => x.GetInfo()));

            var specialCasesProcessed = this.centers.Where(c => c.GetType().FullName.Contains("Police"))
                .Sum(c => c.Emergencies.Sum(x => x.GetInfo()));
          
            var sb = new StringBuilder();
            sb.AppendLine("PRRM Services Live Statistics");
            sb.AppendLine($"Fire Service Centers: {fireCenters}");
            sb.AppendLine($"Medical Service Centers: {medicalCenters}");
            sb.AppendLine($"Police Service Centers: {policeCenters}");
            sb.AppendLine($"Total Processed Emergencies: {this.currentlyRegisteredEmergencies}");
            sb.AppendLine($"Currently Registered Emergencies: {this.emergencies.Count}");
            sb.AppendLine($"Total Property Damage Fixed: {countOfDamageFixed}");
            sb.AppendLine($"Total Health Casualties Saved: {healthCasualtiesSaved}");
            sb.AppendLine($"Total Special Cases Processed: {specialCasesProcessed}");

            return sb.ToString().Trim();
        }
    }
}