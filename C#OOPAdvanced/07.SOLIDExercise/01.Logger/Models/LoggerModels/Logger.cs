namespace _01.Logger.Models.LoggerModels
{
    using _01.Logger.Enums;
    using _01.Logger.Interfaces;
    using System.Collections.Generic;

    public class Logger : ILogger
    {
        private readonly IList<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>(appenders);
        }

        public IList<IAppender> GetAppenders()
        {
            return this.appenders;
        }

        public void Info(string date, string msg)
        {
            this.Append(ReportLevel.Info, date, msg);
        }

        public void Warn(string date, string msg)
        {
            this.Append(ReportLevel.Warn, date, msg);
        }

        public void Error(string date, string msg)
        {
            this.Append(ReportLevel.Error, date, msg);
        }

        public void Critical(string date, string msg)
        {
            this.Append(ReportLevel.Critical, date, msg);
        }

        public void Fatal(string date, string msg)
        {
            this.Append(ReportLevel.Fatal, date, msg);
        }

        private void Append(ReportLevel reportLevel, string date, string msg)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(reportLevel, date, msg);
            }
        }
    }
}