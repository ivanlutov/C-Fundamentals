namespace _01.Logger.Factories
{
    using System;
    using _01.Logger.Enums;
    using _01.Logger.Interfaces;
    using _01.Logger.Models.AppenderModels;

    public class FactoryAppender
    {

        public IAppender Create(string appenderInfo)
        {
            var tokens = appenderInfo.Split();
            var type = tokens[0];
            var layoutType = tokens[1];
            var layoutFactory = new FactoryLayout();
            ILayout layout = layoutFactory.Create(layoutType);

            if (type == "ConsoleAppender")
            {
                var appender =  new ConsoleAppender(layout);
                if (tokens.Length == 3)
                {
                    ReportLevel level = (ReportLevel)Enum.Parse(typeof(ReportLevel), tokens[2], true);
                    appender.LevelOfThreshold = level;
                }

                return appender;
            }
            else if (type == "FileAppender")
            {
                return new FileAppender(layout);
            }

            throw new ArgumentException("The type is not valid");
        }
    }
}