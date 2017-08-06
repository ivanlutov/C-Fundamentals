using System.Collections.Generic;
using BashSoft.DataStructures;

namespace BashSoft.Contracts
{
    public interface IRequester
    {
        void GetStudentMarkInCourse(string courseName, string userName);
        void GetStudentsByCourse(string courseName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);
    }
}
