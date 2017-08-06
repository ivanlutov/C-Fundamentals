using System;
using System.Collections.Generic;
using _04.BubbleSort.Contracts;
namespace _04.BubbleSort.Models
{
    public class Bubble : IBubble
    {
        public IList<int> Sort(IList<int> collection)
        {
            var temp = collection;
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < temp.Count - i - 1; j++)
                {
                    var first = temp[j];
                    var second = temp[j + 1];

                    if (first > second)
                    {
                        var tempValue = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = tempValue;
                    }
                }
            }

            return temp;
        }
    }
}