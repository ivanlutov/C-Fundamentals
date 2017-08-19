namespace Emergency_Skeleton.Factories
{
    using Emergency_Skeleton.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ServiceCenterFactory : IServiceCenterFactory
    {
        public IEmergencyCenter Create(List<string> args)
        {
            var typeOfCenterString = args[0].Replace("Register", "");
            var name = args[1];
            var amountOfEmergencies = int.Parse(args[2]);

            Type typeOfCenter = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeOfCenterString);

            var constructorOfCenter = typeOfCenter.GetConstructor(new[] { typeof(string), typeof(int) });
            var instanceOfCenter = constructorOfCenter.Invoke(new object[] { name, amountOfEmergencies });

            return (IEmergencyCenter)instanceOfCenter;
        }
    }
}