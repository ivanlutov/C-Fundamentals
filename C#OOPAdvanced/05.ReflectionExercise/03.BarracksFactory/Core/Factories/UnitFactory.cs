using System.Reflection;
using _03BarracksFactory.Models.Units;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string unitNameSpace = "_03BarracksFactory.Models.Units.";
        public IUnit CreateUnit(string unitType)
        {
            var typeUnit = Type.GetType($"{unitNameSpace}{unitType}");
            var unitInstance = (IUnit)Activator.CreateInstance(typeUnit, new object[0]);
            return unitInstance;
        }
    }
}
