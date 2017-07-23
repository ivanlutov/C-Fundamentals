namespace BashSoft.Contracts
{
    public interface IRequester
    {
        void GetStudentMarkInCourse(string courseName, string userName);
        void GetStudentsByCourse(string courseName);
    }
}
