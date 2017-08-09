using _01.Logger.Enums;

namespace _01.Logger.Engine
{
    using _01.Logger.Factories;
    using _01.Logger.Interfaces;
    using _01.Logger.Models.LoggerModels;
    using System;

    public class Controller
    {
        private FactoryAppender factoryAppender;
        private FactoryLayout factoryLayout;
        private IWriter writer;
        private IReader reader;

        public Controller(FactoryAppender factoryAppender, FactoryLayout factoryLayout, IWriter writer, IReader reader)
        {
            this.factoryAppender = factoryAppender;
            this.factoryLayout = factoryLayout;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            var numberOfAppenders = int.Parse(Console.ReadLine());
            var appenders = new IAppender[numberOfAppenders];
            for (int i = 0; i < numberOfAppenders; i++)
            {
                var appenderInfo = Console.ReadLine();
                var tokens = appenderInfo.Split();
                var layout = this.factoryLayout.Create(tokens[1]);
                var appender = this.factoryAppender.Create(tokens[0], layout);

                if (tokens.Length == 3)
                {
                    var levelToString = tokens[2];
                    ReportLevel level = (ReportLevel)Enum.Parse(typeof(ReportLevel), levelToString, true);
                    appender.LevelOfThreshold = level;
                }

                appenders[i] = appender;
            }

            var logger = new Logger(appenders);

            var messageInfoLine = reader.ReadLine();
            while (messageInfoLine != "END")
            {
                var messageTokens = messageInfoLine.Split('|');
                var reportLevel = messageTokens[0];
                var date = messageTokens[1];
                var msg = messageTokens[2];

                switch (reportLevel)
                {
                    case "INFO":
                        logger.Info(date, msg);
                        break;

                    case "WARNING":
                        logger.Warn(date, msg);
                        break;

                    case "ERROR":
                        logger.Error(date, msg);
                        break;

                    case "CRITICAL":
                        logger.Critical(date, msg);
                        break;

                    case "FATAL":
                        logger.Fatal(date, msg);
                        break;
                }

                messageInfoLine = reader.ReadLine();
            }

            writer.WriteLine("Logger info");

            foreach (var appender in logger.GetAppenders())
            {
                writer.WriteLine(appender.ToString());
            }
        }
    }
}