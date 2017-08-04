using System;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class Retire : Command
    {
        public Retire(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var result = string.Empty;
            var unitType = this.Data[1];
            try
            {
                this.Repository.RemoveUnit(unitType);
                result = $"{unitType} retired!";
            }
            catch (InvalidOperationException e)
            {
                result = e.Message;
            }

            return result;
        }
    }
}