namespace _01.Logger.Interfaces
{
    using _01.Logger.Enums;

    public interface IAppender
    {
        void Append(ReportLevel reportLevel, string date, string msg);

        ReportLevel LevelOfThreshold { get; set; }
    }
}