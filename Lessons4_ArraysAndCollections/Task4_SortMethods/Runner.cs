using System;
using System.Diagnostics;

namespace Task4_SortMethods
{
    class Program
    {
        public static void Main()
        {
            int[] array = {8, 3, 6, 4, 7, 5};
            int arrayLength = array.Length;
            
            Console.WriteLine("The sorted array: {" + string.Join(", ", array) + "}");
            
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            StoogeSort.Sort(array, 0, arrayLength - 1);
            stopwatch.Stop();
            Console.WriteLine($"Program execution time for Stooge sort : {(stopwatch.Elapsed.TotalMilliseconds).ToString()}");
            
            stopwatch.Reset();
            stopwatch.Start();
            SelectionSort.Sort(array, arrayLength);
            stopwatch.Stop();
            Console.WriteLine($"Program execution time for Selection sort: {(stopwatch.Elapsed.TotalMilliseconds).ToString()}");
        }
    }
}