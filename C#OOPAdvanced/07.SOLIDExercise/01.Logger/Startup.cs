using _01.Logger.Factories;
using _01.Logger.Models.ReaderModels;
using _01.Logger.Models.WriterModels;

namespace _01.Logger
{
    using _01.Logger.Engine;
    using _01.Logger.Interfaces;

    public class Startup
    {
        public static void Main()
        {
            var factoryAppender = new FactoryAppender();
            var factoryLayout = new FactoryLayout();
            IWriter consoleWriter = new ConsoleWriter();
            IReader consoleReader = new ConsoleReader();
            var controller = new Controller(factoryAppender, factoryLayout, consoleWriter, consoleReader);

            controller.Run();
        }
    }
}