namespace _01.Logger.Factories
{
    using _01.Logger.Interfaces;
    using _01.Logger.Models.AppenderModels;
    using System;

    public class FactoryAppender
    {
        public IAppender Create(string type, ILayout layout)
        {
            if (type == "ConsoleAppender")
            {
                return new ConsoleAppender(layout);
            }
            else if (type == "FileAppender")
            {
                return new FileAppender(layout);
            }

            throw new ArgumentException("The type is not valid");
        }
    }
}