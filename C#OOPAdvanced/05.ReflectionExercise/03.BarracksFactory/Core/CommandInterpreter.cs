using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Ninject;
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
            var commandNameType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName);

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandNameType);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var currentInstance = (IExecutable)Activator.CreateInstance(type, new object[] { data });

            var allFields = this.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            var currentInstanceFields = currentInstance.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttributes<InjectAttribute>() != null);


            foreach (var field in currentInstanceFields)
            {
                field
                    .SetValue(currentInstance, allFields.First(f => f.FieldType == field.FieldType)
                    .GetValue(this));
            }

            return currentInstance;
        }
    }
}