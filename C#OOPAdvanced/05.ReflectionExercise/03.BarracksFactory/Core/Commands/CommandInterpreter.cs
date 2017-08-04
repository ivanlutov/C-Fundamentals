using System;
using System.Linq;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class CommandInterpreter : IInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public string InterpretCommand(string input)
        {
            var data = input.Split();
            var commandName = data[0];
            IExecutable command = this.ParseCommand(data, commandName);
            var result = command.Execute();
            return result;
        }
       
        private IExecutable ParseCommand(string[] data, string commandName)
        {
            var firstChar = commandName.First().ToString().ToUpper();
            var otherChars = commandName.Substring(1, commandName.Length - 1);
            var cmd = $"{firstChar}{otherChars}";

            Type type = Type.GetType($"_03BarracksFactory.Core.Commands.{cmd}");
            var instance = (IExecutable)Activator.CreateInstance(type, new object[] { data, this.repository, this.unitFactory });
            return instance;
        }

        
    }
}