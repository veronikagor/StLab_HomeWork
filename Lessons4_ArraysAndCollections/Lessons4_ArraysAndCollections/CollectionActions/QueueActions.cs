using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons4_ArraysAndCollections.CollectionActions
{
    public class QueueActions
    {
        public static int[] CopyQueueToArray(Queue<int> queue)
        {
            int[] array = new int[queue.Count];
            queue.CopyTo(array, 0);
            return array;
        }

        public static int SumOfNumbersBetweenMaximumAndMinimumValues(int[] array)
        {
            int upper = Array.IndexOf(array, array.Max());
            int lower = Array.IndexOf(array, array.Min());
            
            return array.Skip(Math.Min(upper, lower)).Take(Math.Abs(upper - lower) + 1).Sum();
        }
    }
}