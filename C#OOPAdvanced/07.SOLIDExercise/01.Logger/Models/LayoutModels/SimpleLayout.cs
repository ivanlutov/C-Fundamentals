namespace _01.Logger.Models.LayoutModels
{
    using _01.Logger.Enums;
    using _01.Logger.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Formatting(ReportLevel reportLevel, string date, string msg)
        {
            return $"{date} - {reportLevel.ToString().ToUpper()} - {msg}";
        }
    }
}