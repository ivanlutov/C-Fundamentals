namespace Emergency_Skeleton.Factories
{
    using Emergency_Skeleton.Contracts;
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class EmergencyFactory : IEmergencyFactory
    {
        private const string Preffix = "Public";

        public IEmergency Create(List<string> args)
        {
            var typeOfEmergencyToString = args[0].Replace("Register", Preffix);
            var name = args[1];

            EmergencyLevel emergencyLevel = (EmergencyLevel)Enum.Parse(typeof(EmergencyLevel), args[2]);
            var registrationTimeToString = args[3];
            var lastParameter = args[4];

            Type typeOfRegistrationTime = typeof(RegistrationTime);
            var constructorOfRegistrationTime = typeOfRegistrationTime.GetConstructor(new[] { typeof(string) });
            var instanceOfRegistrationTime = constructorOfRegistrationTime.Invoke(new object[] { registrationTimeToString });

            var allTypes = Assembly.GetExecutingAssembly().GetTypes();
            var emergencyType = allTypes.FirstOrDefault(t => t.Name == typeOfEmergencyToString);
            var constructorOfEmergency = emergencyType.GetConstructors().FirstOrDefault();

            var argsToPass = new object[args.Count - 1];
            argsToPass[0] = name;
            argsToPass[1] = emergencyLevel;
            argsToPass[2] = instanceOfRegistrationTime;

            if (typeOfEmergencyToString == "PublicHealthEmergency" || typeOfEmergencyToString == "PublicPropertyEmergency")
            {
                argsToPass[3] = int.Parse(lastParameter);
            }
            else
            {
                argsToPass[3] = lastParameter;
            }

            return (IEmergency)constructorOfEmergency.Invoke(argsToPass);
        }
    }
}