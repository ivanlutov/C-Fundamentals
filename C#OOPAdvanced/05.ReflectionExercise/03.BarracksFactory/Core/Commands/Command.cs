using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public string[] Data { get => data; set => data = value; }
        public IRepository Repository { get => repository; set => repository = value; }
        public IUnitFactory UnitFactory { get => unitFactory; set => unitFactory = value; }

        public abstract string Execute();
    }
}