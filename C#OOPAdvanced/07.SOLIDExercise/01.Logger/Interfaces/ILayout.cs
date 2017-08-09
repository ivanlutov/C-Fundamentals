namespace _01.Logger.Interfaces
{
    using _01.Logger.Enums;

    public interface ILayout
    {
        string Formatting(ReportLevel reportLevel, string date, string msg);
    }
}