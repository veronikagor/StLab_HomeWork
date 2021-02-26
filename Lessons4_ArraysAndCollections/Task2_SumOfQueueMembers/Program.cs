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
        public Queue<int> CreateQueue()
        {
            const int minCountOfNumbers = 1;
            const int maxCountOfNumbers = 11;

            Random random = new Random();
            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < maxCountOfNumbers - 1; i++)
            {
                numbers.Enqueue(random.Next(minCountOfNumbers, maxCountOfNumbers));
            }

            Console.WriteLine("Queue is created: {" + string.Join(", ", numbers) + "}");
            return numbers;
        }

        public int[] CopyQueueToArray(Queue<int> numbers)
        {
            int[] array = new int[numbers.Count];
            numbers.CopyTo(array, 0);
            return array;
        }

        public void SumOfNumbers(int[] array)
        {
            int upper = Array.IndexOf(array, array.Max());
            int lower = Array.IndexOf(array, array.Min());
            int sum = array.Skip(Math.Min(upper, lower)).Take(Math.Abs(upper - lower) + 1).Sum();

            Console.WriteLine($"Sum of numbers between upper and lower numbers in queue is {sum}");
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            var queue = program.CreateQueue();
            var numbers = program.CopyQueueToArray(queue);
            program.SumOfNumbers(numbers);
        }
    }
}