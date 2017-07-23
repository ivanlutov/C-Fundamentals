using System.Collections.Generic;

namespace BashSoft.Contracts
{
    public interface IDataSorter
    {
        void OrderAndTake(Dictionary<string, double> studentsMarks, string comparison, int studentsToTake);
    }
}