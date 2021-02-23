using System;
using System.Collections.Generic;
using System.Linq;

/* Given a sequence of N distinct integers entered in the queue.
 * Find the sum of its members located between the maximum and minimum values 
 * (include both of these numbers in the sum).
 */
namespace Task2_SumOfQueueMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                numbers.Enqueue(random.Next(1, 100));
            }

            int[] array = new int[10];
            numbers.CopyTo(array, 0);
            Console.WriteLine("Queue: {" + string.Join(", ", array) + "}");

            int upper = Array.IndexOf(array, array.Max());
            int lower = Array.IndexOf(array, array.Min());
            int sum = array.Skip(Math.Min(upper, lower)).Take(Math.Abs(upper - lower) + 1).Sum();
            Console.WriteLine($"Sum of numbers between upper and lower numbers in queue is {sum}");
        }
    }
}