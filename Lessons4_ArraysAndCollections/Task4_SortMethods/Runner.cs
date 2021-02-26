using System;
using System.Diagnostics;

namespace Task4_SortMethods
{
    class Program
    {
        public static void Main()
        {
            var createdArray = ArrayGenerator.CreateArray();
            int arrayLength = createdArray.Length;

            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            StoogeSort.Sort(createdArray, 0, arrayLength - 1);
            stopwatch.Stop();
            Console.WriteLine("The array sorted by stoog sort: {" 
                              + string.Join(", ", createdArray) + "} in " + (stopwatch.Elapsed.TotalMilliseconds) + " milliseconds");
            
            stopwatch.Reset();
            stopwatch.Start();
            SelectionSort.Sort(createdArray, arrayLength);
            stopwatch.Stop();
            Console.WriteLine("The array sorted by selection sort: {" 
                              + string.Join(", ", createdArray) + "} in " + (stopwatch.Elapsed.TotalMilliseconds) + " milliseconds");
            
        }
    }
}