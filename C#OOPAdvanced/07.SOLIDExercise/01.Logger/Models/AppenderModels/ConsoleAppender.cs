namespace _01.Logger.Models.AppenderModels
{
    using _01.Logger.Enums;
    using _01.Logger.Interfaces;
    using System;

    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        private int countOfMessage;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel LevelOfThreshold { get; set; }

        public void Append(ReportLevel reportLevel, string date, string msg)
        {
            if (this.LevelOfThreshold <= reportLevel)
            {
                this.countOfMessage++;
                var formattedMsg = this.layout.Formatting(reportLevel, date, msg);
                Console.WriteLine(formattedMsg);
            }
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.LevelOfThreshold}, Messages appended: {this.countOfMessage}";
        }
    }
}