using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons4_ArraysAndCollections.RandomUtils
{
    public class CollectionCreation
    {
        static Random random = new Random();

        public static Queue<int> GenerateRandomNumbersForQueue(int minCountOfNumbers, int maxCountOfNumbers)
        {
            var queue = new Queue<int>();

            for (int i = 0; i < maxCountOfNumbers - 1; i++)
            {
                queue.Enqueue(random.Next(minCountOfNumbers, maxCountOfNumbers));
            }

            Console.WriteLine("Queue is created: {" + string.Join(", ", queue) + "}");
            return queue;
        }

        public static Stack<int> GenerateRandomNumbersForStack(int minCountOfNumbers, int maxCountOfNumbers)
        {
            var stack = new Stack<int>();

            for (int i = 0; i < maxCountOfNumbers - 1; i++)
            {
                stack.Push(random.Next(minCountOfNumbers, maxCountOfNumbers));
            }

            Console.WriteLine("Stack is created: {" + string.Join(", ", stack) + "}");
            return stack;
        }

        public static LinkedList<int> GenerateRandomNumbersForList(int listLength)
        {
            var linkedList = new LinkedList<int>(Enumerable.Range(1, listLength));

            Console.WriteLine("Peoples number in the circle: {" + string.Join(", ", linkedList) + "}");
            return linkedList;
        }

        public static int[] GenerateRandomNumbersForArray(int minArrayLength, int maxArrayLength)
        {
            var array = new int[random.Next(minArrayLength, maxArrayLength)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }

            Console.WriteLine($"The created array: {string.Join(", ", array)}");
            return array;
        }
    }
}