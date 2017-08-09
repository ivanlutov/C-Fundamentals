namespace _01.Logger.Interfaces
{
    using _01.Logger.Enums;

    public interface ILogger
    {
        void Info(string date, string msg);
        void Warn(string date, string msg);
        void Error(string date, string msg);
        void Critical(string date, string msg);
        void Fatal(string date, string msg);
    }
}