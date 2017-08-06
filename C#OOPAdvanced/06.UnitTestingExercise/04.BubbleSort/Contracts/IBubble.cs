using System.Collections.Generic;

namespace _04.BubbleSort.Contracts
{
    public interface IBubble
    {
        IList<int> Sort(IList<int> collection);
    }
}